using System.Data.SqlClient;
using System.Data;

namespace OMR_Test
{
    class DatabaseClient
    {
        public void SendData(Blanc blanc)
        {
            SqlConnection connection = new SqlConnection(Path.ConnectionString);

            try
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT id FROM students WHERE name='{blanc.Name}' AND surname='{blanc.LastName}' AND grp='{blanc.Group}';";

                SqlDataReader rowsReader = command.ExecuteReader();
                bool hasRows = rowsReader.HasRows;
                rowsReader.Close();

                if (!hasRows)
                {
                    SqlCommand insertStudentData = new SqlCommand();
                    insertStudentData.CommandType = CommandType.Text;
                    insertStudentData.Connection = connection;
                    insertStudentData.CommandText = $"INSERT INTO students(name, surname, grp) VALUES('{blanc.Name}', '{blanc.LastName}', '{blanc.Group}');";
                    insertStudentData.ExecuteNonQuery();
                }

                SqlDataReader intReader = command.ExecuteReader();
                intReader.Read();
                int id = intReader.GetInt32(0);
                intReader.Close();

                SqlCommand insertBlancData = new SqlCommand();
                insertBlancData.CommandType = CommandType.Text;
                insertBlancData.Connection = connection;
                insertBlancData.CommandText = $"INSERT INTO marks VALUES({id}, {blanc.Result.ToString().Replace(',', '.')}, '{blanc.Subject}', '{blanc.Date.Year}-{blanc.Date.Month}-{blanc.Date.Day} {blanc.Date.Hour}:{blanc.Date.Minute}:{blanc.Date.Second}');";
                insertBlancData.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
