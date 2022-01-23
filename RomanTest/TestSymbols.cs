using NUnit.Framework;
using Roman;
using System;

namespace RomanTest
{
    [TestFixture]
    public class TestSymbols
    {
        [Test]
        [TestCase(1,"I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(9, "IX")]
        [TestCase(21, "XXI")]
        [TestCase(50, "L")]
        [TestCase(100, "C")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        public void ConvertRoman(int number,string expected)
        {
            string actual= RomanNumber.ConvertToRoman(number);
            Assert.AreEqual(expected, actual);
        }

    }
}
