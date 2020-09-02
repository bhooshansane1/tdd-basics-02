using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        private readonly Calculator cal = new Calculator();

        [Fact]
        public void Invalid_Keys_Pressed_Test()
        {
            cal.SendKeyPress('1');
            cal.SendKeyPress('+');
            cal.SendKeyPress('2');
            cal.SendKeyPress('u');
            Assert.Equal("3", cal.SendKeyPress('='));
        }

        [Fact]
        public void Reset_Calculator_Test()
        {
            cal.SendKeyPress('1');
            cal.SendKeyPress('+');
            cal.SendKeyPress('2');
            cal.SendKeyPress('+');

            Assert.Equal("0", cal.SendKeyPress('c'));
        }

        [Fact]
        public void Divide_By_Zero_Error_Test()
        {
            cal.SendKeyPress('1');
            cal.SendKeyPress('0');
            cal.SendKeyPress('/');
            cal.SendKeyPress('0');

            Assert.Equal("-E-", cal.SendKeyPress('='));
        }

        [Fact]
        public void Toggle_Sign_Test()
        {
            cal.SendKeyPress('1');
            cal.SendKeyPress('2');
            cal.SendKeyPress('+');
            cal.SendKeyPress('2');
            cal.SendKeyPress('s');
            cal.SendKeyPress('s');
            cal.SendKeyPress('s');
            Assert.Equal("10", cal.SendKeyPress('='));
        }

        [Fact]
        public void Multiple_Decimal_Point_Test()
        {
            cal.SendKeyPress('0');
            cal.SendKeyPress('0');
            cal.SendKeyPress('.');
            cal.SendKeyPress('.');
            cal.SendKeyPress('0');
            cal.SendKeyPress('0');

            Assert.Equal("0.001", cal.SendKeyPress('1'));
        }

        [Fact]
        public void Case_Insensitivity_Test()
        {
            cal.SendKeyPress('2');
            cal.SendKeyPress('3');
            cal.SendKeyPress('4');
            
            Assert.Equal("0", cal.SendKeyPress('C'));
        }

        [Fact]
        public void Valid_Calculate_Test()
        {
            cal.SendKeyPress('1');
            cal.SendKeyPress('8');
            cal.SendKeyPress('0');
            cal.SendKeyPress('+');
            cal.SendKeyPress('8');
            cal.SendKeyPress('9');
            cal.SendKeyPress('-');
            cal.SendKeyPress('8');
            cal.SendKeyPress('0');

            Assert.Equal("189", cal.SendKeyPress('='));
        }

        [Fact]
        public void Math_Operator_At_Last_Test()
        {
            cal.SendKeyPress('C');
            cal.SendKeyPress('1');
            cal.SendKeyPress('+');
            cal.SendKeyPress('2');
            cal.SendKeyPress('+');
            cal.SendKeyPress('3');
            cal.SendKeyPress('+');

            Assert.Equal("12", cal.SendKeyPress('='));

            cal.SendKeyPress('C');
            cal.SendKeyPress('1');
            cal.SendKeyPress('+');
            cal.SendKeyPress('2');
            cal.SendKeyPress('+');
            cal.SendKeyPress('3');
            cal.SendKeyPress('-');

            Assert.Equal("0", cal.SendKeyPress('='));

            cal.SendKeyPress('C');
            cal.SendKeyPress('1');
            cal.SendKeyPress('+');
            cal.SendKeyPress('2');
            cal.SendKeyPress('+');
            cal.SendKeyPress('3');
            cal.SendKeyPress('x');

            Assert.Equal("36", cal.SendKeyPress('='));

            cal.SendKeyPress('C');
            cal.SendKeyPress('1');
            cal.SendKeyPress('+');
            cal.SendKeyPress('2');
            cal.SendKeyPress('+');
            cal.SendKeyPress('3');
            cal.SendKeyPress('/');

            Assert.Equal("1", cal.SendKeyPress('='));
        }

    }
}
