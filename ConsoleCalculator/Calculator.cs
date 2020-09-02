using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleCalculator
{
    public class Calculator:ICalculator
    {
        //public void calculate()
        //{
        //    throw new NotImplementedException();
        //}
        //public string SendKeyPress(char key) => throw new NotImplementedException();


        private readonly StringBuilder calcStr = new StringBuilder();
        readonly CalculatorProperty property = new CalculatorProperty();

        public void calculate()
        {
            if (double.TryParse(calcStr.ToString(), out double temp))
            {
                property.errorChar = null;
                switch (property.lastOperation)
                {
                    case '\0':
                        property.result = temp;
                        break;
                    case '+':
                        property.result += temp;
                        break;
                    case '-':
                        property.result -= temp;
                        break;
                    case 'x':
                        property.result *= temp;
                        break;
                    case '/':

                        if (temp != 0)
                        {
                            property.result /= temp;
                        }
                        else
                            property.errorChar = "-E-";
                        break;
                    case '=':
                        calcStr.Clear();
                        break;
                    default:
                        break;
                }
            }
            else if (property.lastOperation == '=' && string.IsNullOrWhiteSpace(calcStr.ToString()))
            {
                switch (property.lastMathOperation)
                {
                    case '+':
                        property.result += property.lastNumber;
                        break;
                    case '-':
                        property.result -= property.lastNumber;
                        break;
                    case 'x':
                        property.result *= property.lastNumber;
                        break;
                    case '/':
                        property.result /= property.lastNumber;
                        break;
                    default:
                        break;
                }
            }
        }

        public string SendKeyPress(char key)
        {
            if (IsValidCharacter(key))
            {
                if (Utility.IsDigit(key))
                {
                    if (calcStr.ToString() == "0" && key == '0')
                    {
                        return calcStr.ToString();
                    }
                    else if (calcStr.ToString() == "0" && key != '0')
                    {
                        calcStr.Clear();
                    }

                    calcStr.Append(key.ToString()).ToString();
                    property.lastNumber = double.Parse(calcStr.ToString());
                    return calcStr.ToString();
                }
                else if (Utility.IsDecimalPoint(key))
                {
                    if (calcStr.Length > 0 && !calcStr.ToString().Contains("."))
                    {
                        return calcStr.Append(key.ToString()).ToString();
                    }
                    else
                        return calcStr.ToString();
                }
                else if (Utility.IsOperator(key))
                {
                    if (property.lastOperation != '=' && property.lastOperation != '\0')
                        property.lastNumber = property.result;

                    calculate();
                    property.lastOperation = key;
                    if (key == '=' && property.errorChar == null)
                    {
                        calculate();
                        calcStr.Append(property.result.ToString());
                    }
                    else
                        property.lastMathOperation = key;
                    calcStr.Clear();
                }
                else if (IsReset(key))
                {
                    return Reset();
                }
                else if (IsSign(key) && calcStr.Length > 0)
                {
                    return ChangeSign();
                }
            }
            return property.errorChar ?? property.result.ToString();
        }

        private string ChangeSign()
        {
            string tempStr = (double.Parse(calcStr.ToString()) * -1).ToString();
            calcStr.Clear();
            return calcStr.Append(tempStr).ToString();
        }
        private string Reset()
        {
            calcStr.Clear();
            property.result = 0;
            property.lastOperation = '\0';
            return CalculatorProperty.resetChar;
        }
        private bool IsSign(char key)
        {
            return (char.ToLower(key) == 's');
        }
        private bool IsReset(char key)
        {
            return key == 'c' || key == 'C';
        }
        private bool IsValidCharacter(char key)
        {
            return Utility.IsDigit(key) || Utility.IsOperator(key) || IsReset(key) || IsSign(key) || Utility.IsDecimalPoint(key);
        }
    }
}
