using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    internal class CalculatorProperty
    {
        internal const string resetChar = "0";

        internal StringBuilder calcStr = new StringBuilder();
        internal string errorChar { get; set; }
        internal char lastOperation { get; set; }
        internal char lastMathOperation { get; set; }
        internal double lastNumber { get; set; }
        internal double result { get; set; }

        public CalculatorProperty()
        {
            errorChar = null;
            lastOperation = '\0';
            result = 0;
        }
    }
}
