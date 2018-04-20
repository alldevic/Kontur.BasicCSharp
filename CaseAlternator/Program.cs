using System;

namespace CaseAlternator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var strings = CaseAlternatorTask.AlternateCharCases("ab42");
            foreach (var str in strings)
            {
                Console.WriteLine(str);
            }
        }
    }
}