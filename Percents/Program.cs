using System;

namespace Percents
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var userInput = Console.ReadLine();
            Console.WriteLine(PercentsTask.Calculate(userInput));
        }
    }
}