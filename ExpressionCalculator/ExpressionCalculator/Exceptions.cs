using System;

namespace ExpressionCalculator
{
    static class Exceptions
    {
        public static void CheckBrackets (string exp)
        {
            int counter = 0;

            for (int i = 0, l = exp.Length; i < l; ++i)
            {
                if (exp[i] == '(')
                {
                    ++counter;
                }
                else if (exp[i] == ')')
                {
                    --counter;
                }

                if (counter == -1)
                {
                    throw new FormatException($"Extra close bracket at the beginning of\n{exp.Substring(i)}");
                }
            }

            if (counter > 0)
            {
                throw new FormatException("Missing close brackets. Check your expression");
            }
        }
    }
}