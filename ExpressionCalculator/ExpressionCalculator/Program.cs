using System;
using System.Collections.Generic;
using static System.Console;

namespace ExpressionCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter your expression. For example: 3 * x + sin ( 25 - 3 / ( ++ a ) )\nDon't forget about whitespaces");

            while (true)
            {
                string exp = ReadLine();

                if (exp == "Quit")
                {
                    break;
                }
                else if (exp == "")
                {
                    WriteLine("Please, enter the expression");
                }
                else
                {
                    Machine m = new Machine();

                    try
                    {
                        m.CalculateExpression(exp);
                    }
                    catch (FormatException exc)
                    {
                        WriteLine(exc.Message);
                    }
                }
            }
        }
    }

    class Machine
    {
        Dictionary<string, int> binaryOperators = new Dictionary<string, int>
        {
            {"*", 3}, {"/", 3}, {"+", 2}, {"-", 2}, {"(", 1}
        };

        Dictionary<string, int> unaryOperatorsAndFunctions = new Dictionary<string, int>
        {
            {"sin", 4}, {"cos", 4}, {"++", 5}, {"--", 5}, {"exp", 4}
        };

        public void CalculateExpression(string exp)
        {
            Exceptions.CheckBrackets(exp);

            string[] tokens = GetTokens(exp);

            dynamic[] d_tokens = GetDynamicTokens(tokens);
            
            CalculateExpression(d_tokens);
        }

        private void AddRange<TKey, TValue>(ref Dictionary<TKey, TValue> target, Dictionary<TKey, TValue> range)
        {
            foreach (var pair in range)
            {
                target.Add(pair.Key, pair.Value);
            }
        }

        private string[] GetTokens(string exp)
        {
            Dictionary<string, int> operators = new Dictionary<string, int>();
            AddRange(ref operators, binaryOperators);
            AddRange(ref operators, unaryOperatorsAndFunctions);

            string[] tokens = exp.Split(' ');
            Stack<string> operatorStack = new Stack<string>();
            List<string> resultList = new List<string>();

            foreach (string t in tokens)
            {
                if (t == "(")
                {
                    operatorStack.Push(t);
                }
                else if (t == ")")
                {
                    string top = operatorStack.Pop();

                    while (top != "(")
                    {
                        resultList.Add(top);
                        top = operatorStack.Pop();
                    }
                }
                else if (operators.ContainsKey(t))
                {
                    while (operatorStack.Count != 0 && operators[operatorStack.Peek()] >= operators[t])
                    {
                        resultList.Add(operatorStack.Pop());
                    }

                    operatorStack.Push(t);
                }
                else
                {
                    resultList.Add(t);
                }
            }

            while (operatorStack.Count != 0)
            {
                resultList.Add(operatorStack.Pop());
            }

            return resultList.ToArray();
        }

        private dynamic[] GetDynamicTokens(string[] tokens)
        {
            int length = tokens.Length;

            dynamic[] dynamicArray = new dynamic[length];

            for (int i = 0; i < length; ++i)
            {
                string token = tokens[i];
                double result;

                if (double.TryParse(token, out result))
                {
                    dynamicArray[i] = result;
                }
                else
                {
                    dynamicArray[i] = token;
                }
            }

            return dynamicArray;
        }

        private dynamic[] SwitchTokens(dynamic[] array, dynamic[] values)
        {
            int length = array.Length;

            dynamic[] result = new dynamic[length];

            for (int i = 0, v = 0; i < length; ++i)
            {
                if (array[i] is string && !binaryOperators.ContainsKey(array[i]) && !unaryOperatorsAndFunctions.ContainsKey(array[i]))
                {
                    result[i] = values[v];
                    ++v;
                }
                else
                {
                    result[i] = array[i];
                }
            }

            return result;
        }
        
        private void CalculateExpression(dynamic[] tokens)
        {
            //temporary solution
            List<dynamic[]> tokensList = new List<dynamic[]>()
            {
                //SwitchTokens(tokens, new dynamic[] {2.0, 3.0}),
                //SwitchTokens(tokens, new dynamic[] {3.0, 4.0})
                tokens
            };

            foreach (dynamic[] array in tokensList)
            {
                Stack<dynamic> stack = new Stack<dynamic>();

                foreach (dynamic t in array)
                {
                    if (binaryOperators.ContainsKey(t.ToString()))
                    {
                        dynamic a = stack.Pop();
                        dynamic b = stack.Pop();

                        switch ((string)t)
                        {
                            case "+":
                                stack.Push(b + a);
                                break;
                            case "-":
                                stack.Push(b - a);
                                break;
                            case "*":
                                stack.Push(b * a);
                                break;
                            case "/":
                                stack.Push(b / a);
                                break;
                        }
                    }
                    else if (unaryOperatorsAndFunctions.ContainsKey(t.ToString()))
                    {
                        dynamic e = stack.Pop();

                        switch((string)t)
                        {
                            case "++":
                                stack.Push(++e);
                                break;
                            case "--":
                                stack.Push(--e);
                                break;
                            case "sin":
                                stack.Push(Math.Sin(e));
                                break;
                            case "cos":
                                stack.Push(Math.Cos(e));
                                break;
                            case "exp":
                                stack.Push(Math.Pow(Math.E, e));
                                break;
                        }
                    }
                    else
                    {
                        stack.Push(t);
                    }
                }

                WriteLine(stack.Pop());
            }
        } 
    }
}