using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public static class Utility 
    {
        public static bool IsDecimalPoint(char key)
        {
            return key == '.';
        }

        public static bool IsDigit(char key)
        {
            return Char.IsDigit(key);
        }

        public static bool IsOperator(char key)
        {
            return key == '+' || key == '-' || Char.ToLower(key) == 'x' || key == '/' || key == '=';
        }
    }
}
