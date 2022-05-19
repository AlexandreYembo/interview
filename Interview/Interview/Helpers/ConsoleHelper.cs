using System;

namespace Interview.Helpers
{
    public static class ConsoleHelper
    {
        public static void PrintOutput(string message)
        {
            Print.PrintLine();
            Console.BackgroundColor = ConsoleColor.Red;
            Print.PrintRow(message);
            Console.ResetColor();
            Print.PrintLine();
        }
    }
}
