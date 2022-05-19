using System;
using System.Linq;

namespace Interview.Factory
{
    public static class Instance
    {
        //Create instance for a specific class defined on input of the program.
        private static ICode GetInstance(string folder, string className)
        {
            folder = Trim(folder);
            className = Trim(className);

            return (ICode)Activator.CreateInstance(Type.GetType($"Interview.Code.{folder}.{className}"));
        }

        private static string Trim(string folder)
        {
            folder = new string
            (folder
                .Where
                (
                    c => !char.IsWhiteSpace(c)
                )
                .ToArray<char>()
            );
            return folder;
        }

        public static void Run(string folder, string className) => GetInstance(folder, className).Run();
    }
}