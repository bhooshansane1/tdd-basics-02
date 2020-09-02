using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ConsoleCalculator
{
    interface ICalculator
    {
        void calculate();
        string SendKeyPress(char key);
    }
}
