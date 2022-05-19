using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Interview.Factory;
using Interview.Helpers;

namespace Interview
{
    public class Program
    {
        static int tableWidth = 73;

        static void Main(string[] args)
        {
            var menu = GetMenu();
            Console.Clear();
            Console.Write($"Select the operation number from the menu: \n ");

            Print.PrintLine();
            Print.PrintRow("Operation Number", "Category", "Operation Name");
            Print.PrintLine();
            menu.ForEach(m => Print.PrintRow(m.operation, m.folder, m.className));
            Print.PrintLine();
            var operation = Console.ReadLine();
            var operationClass = menu.FirstOrDefault(m => m.operation == operation);
            Instance.Run(operationClass.folder, operationClass.className);

            Print.PrintRow("Press R to try again!");
            var info = Console.ReadKey();
            if (info.Key == ConsoleKey.R)
            {
                //Start process, friendly name is something like MyApp.exe (from current bin directory)
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);

                //Close the current process
                Environment.Exit(0);
            }
        }


        private static List<(string operation, string folder, string className)> GetMenu()
        {
            return new List<(string operation, string folder, string className)>()
            {
                ("1", "Data Structures.Arrays", "Two Sum")
            };
        }

       
    }
}
