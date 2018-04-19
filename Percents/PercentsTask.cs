using System;

namespace Percents
{
    public static class PercentsTask
    {
        public static double Calculate(string userInput)
        {
            var args = userInput.Split(' ');

            double totalMoney = double.Parse(args[0]),
                monthRate = double.Parse(args[1]) / 12,
                termOfDeposit = double.Parse(args[2]);

            return totalMoney * Math.Pow(1 + monthRate / 100, termOfDeposit);
        }
    }
}