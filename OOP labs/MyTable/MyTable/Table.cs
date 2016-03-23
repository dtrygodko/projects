using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace MyTable
{
    class MyTable
    {
        SqlConnection connection;

        public string Name { get; }

        Dictionary<string, string> parameters;

        public MyTable(string connectionString, string tableName, Dictionary<string, string> parameters)
        {
            connection = new SqlConnection(connectionString);
            Name = tableName;
            
            if (parameters != null && parameters.Count != 0)
            {
                if (CheckTable())
                {
                    this.parameters = parameters;

                    CreateTable();
                }
                else
                {
                    this.parameters = new Dictionary<string, string>();

                    Connect();
                }
            }
            else
            {
                throw new NullReferenceException("Parameters must have at least one key-value pair");
            }
        }

        bool CheckTable()
        {
            try
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM " + Name + ";";
                command.ExecuteNonQuery();

                return false;
            }
            catch
            {
                return true;
            }
            finally
            {
                connection.Close();
            }
        }

        void Connect()
        {
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM " + Name + ";";

            var schema = command.ExecuteReader().GetSchemaTable();
            
            for (int i = 0; i < schema.Rows.Count; ++i)
            {
                parameters.Add(schema.Rows[i].ItemArray[0].ToString(), ((SqlDbType)(int)schema.Rows[i]["ProviderType"]).ToString());
            }

            connection.Close();
        }

        void CreateTable()
        {
            string commandText = "CREATE TABLE " + Name + "(";

            foreach(var parameter in parameters)
            {
                commandText += parameter.Key + " " + parameter.Value + ",";
            }

            commandText = commandText.Trim(',');
            commandText += ");";

            ExecuteCommand(commandText);
        }

        void ExecuteCommand(string commandText)
        {
            try
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = commandText;
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        void ValidateParameters(IEnumerable parameters)
        {
            foreach (string col in parameters)
            {
                if (!this.parameters.Keys.Contains(col))
                {
                    throw new ArgumentException($"Table doesn't have {col}");
                }
            }
        }

        void Concat(IEnumerable collection, ref string text)
        {
            foreach(string element in collection)
            {
                text += element + ",";
            }

            text = text.Trim(',');
        }

        public DataRow[] Select(List<string> columns = null, string condition = "")
        {
            try
            {
                string commandText = "SELECT ";

                if (columns == null || columns.Count == 0)
                {
                    commandText += "*";
                }
                else
                {
                    ValidateParameters(columns);

                    Concat(columns, ref commandText);
                }

                commandText += " FROM " + Name + " " + condition + ";";

                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = commandText;

                DataTable dataTable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dataTable);

                connection.Close();
                da.Dispose();

                return dataTable.Select();
            }
            catch (SqlException e)
            {
                connection.Close();

                throw new Exception("Error in condition", e);
            }
        }

        public void Insert(Dictionary<string, string> values)
        {
            ValidateParameters(values.Keys);
            
            string commandText = "INSERT INTO " + Name + "(";

            Concat(values.Keys, ref commandText);

            commandText += ") VALUES(";

            Concat(values.Values, ref commandText);

            commandText += ");";

            ExecuteCommand(commandText);
        }

        public void Insert(List<string> values)
        {
            string commandText = "INSERT INTO " + Name + " VALUES(";

            Concat(values, ref commandText);

            commandText += ");";

            ExecuteCommand(commandText);
        }

        public void Update(Dictionary<string, string> valuesToSet, string condition)
        {
            ValidateParameters(valuesToSet.Keys);
            
            string commandText = "UPDATE " + Name + " SET ";

            foreach(var pair in valuesToSet)
            {
                commandText += pair.Key + " = " + pair.Value + ",";
            }

            commandText = commandText.Trim(',');
            commandText += " " + condition;

            ExecuteCommand(commandText);
        }
    }
}
