using FizzBuzz;
using NUnit.Framework;

namespace FizzBuzzTest
{
    [TestFixture]
    public class FizzBuzzCheck
    {
        [Test]
        [TestCase(3,"Fizz")]
        [TestCase(1, "1")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(12, "Fizz")]
        [TestCase(30, "FizzBuzz")]
        [TestCase(11, "11")]
        [TestCase(8, "8")]
        [TestCase(17, "17")]
        public void Print_Fizz_WhenModeThreeisZero(int digit,string expected)
        {
           var actual= FizzBuzzPrint.Print(digit);
            Assert.AreEqual(expected, actual);
        }
    }
}
