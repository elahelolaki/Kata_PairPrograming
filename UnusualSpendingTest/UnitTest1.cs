using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using UnusualSpending;

namespace UnusualSpendingTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var transction= new Transaction(2);
            transction.AddPayment(1, 50, new System.DateTime(2022, 01, 15), Category.groceries);
            transction.AddPayment(1, 60, new System.DateTime(2022, 01, 16), Category.travel);
            transction.AddPayment(1, 10, new System.DateTime(2022, 01, 10), Category.golf);
            transction.AddPayment(1, 12, new System.DateTime(2022, 02, 16), Category.golf);
            transction.AddPayment(1, 198, new System.DateTime(2022, 02, 23), Category.groceries);
            transction.AddPayment(1, 978, new System.DateTime(2022, 02, 12), Category.travel);
            transction.AddPayment(1, 100, new System.DateTime(2022, 02, 22), Category.restaurants);
            var ss= transction.UnusuallyHigh(1);

            StringReader stringReader = new StringReader(ss);
            Console.SetIn(stringReader);
            var actual = string.Empty;
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                actual += line + "\n";
            }
            if (actual.Length > 0)
                actual = actual.Substring(0, actual.Length - 1);
            string expected = "Hello card user!\nWe have detected unusually high spending on your card in these categories:\n*You spent $148 on groceries\n*You spent $918 on travel\nLove,\nThe Credit Card Company";
            Assert.AreEqual(expected,actual);
        }
    }
}