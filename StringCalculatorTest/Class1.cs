using NUnit.Framework;
using StringCalculator;
using System;

namespace StringCalculatorTest
{
    [TestFixture]
    public class AddTest
    {
        Calculator calculator;
        
        [SetUp]
        public void setup()
        {
            calculator = new Calculator();
        }
        

        [Test]
        [TestCase("",0)]
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("1,2", 3)]
        [TestCase("1\n2,3",6)] 
        [TestCase("//;\n1;2", 3)]
        [TestCase("2,1001", 2)]
        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[*][%]\n1*2%3", 6)]
        public void Add_TestSimple_ReturnSum(string number,int expected)
        { 

            //Act
            int actual= calculator.Add(number);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("1,\n" )]
        public void add_negative_throws(string number)
        { 
            var ex = Assert.Throws<Exception>(() => calculator.Add(number));
            Assert.AreEqual("NOT ok", ex.Message);
        }

        [Test]
        [TestCase("-1,2")]
        public void add_negative_throws_1(string number)
        {
            var ex = Assert.Throws<Exception>(() => calculator.Add(number));
            Assert.AreEqual("negatives not allowed", ex.Message);
        }
    }
}
