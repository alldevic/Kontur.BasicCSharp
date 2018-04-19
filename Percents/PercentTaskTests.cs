using NUnit.Framework;

namespace Percents
{
    [TestFixture]
    public class PercentTaskTests
    {
        [TestCase("1000 24 3", 1061.208)]
        public void CalculateTest(string userInput, double res)
        {
            Assert.That(PercentsTask.Calculate(userInput), Is.EqualTo(res));
        }
    }
}