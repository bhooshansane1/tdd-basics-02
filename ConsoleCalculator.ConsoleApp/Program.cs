using System;

namespace ConsoleCalculator.App
{
    class Program
    {
        public static void Main()
        {
            var calc = new Calculator();
            ConsoleKeyInfo key;
            Console.WriteLine("0");
            Console.WriteLine("Press Ctrl + C to close the program.");
            
            while (IsKillSwitch(key = Console.ReadKey(true)) == false)
            {
                Console.Clear();
                Console.WriteLine(calc.SendKeyPress(key.KeyChar));
            }
        }

        private static bool IsKillSwitch(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.X && key.Modifiers == ConsoleModifiers.Control;
        }
    }
}
