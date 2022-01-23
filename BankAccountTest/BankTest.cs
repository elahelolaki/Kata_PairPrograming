using BankAccount;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace BankAccountTest
{
    [TestFixture]
    public class BankTest
    {

        [Test]
        [TestCase(500,100,600)]
        public void Deposit_BalanceIncrease_whenAddAmount(int initalBalance, int amount, int expected)
        {
            Account account = new Account(initalBalance);

            account.Deposit(amount);

            Assert.AreEqual(expected, account.Balance);
        }



        [Test]
        [TestCase(500, 100, 400)]
        public void Withdraw_BalanceDecrease_whenSubtractAmount(int initalBalance, int amount, int expected)
        {
            Account account = new Account(initalBalance);

            account.Withdraw(amount);

            Assert.AreEqual(expected, account.Balance);
        }



        [Test]
        [TestCase("Date \t Amount \t Balance\n16/01/2022 \t 1000 \t 1500\n16/01/2022 \t -200 \t 1300")]
        public void PrintStatement_ShowLog(string expected)
        {
            Account account = new Account(500);
            DateTime logDate = new DateTime(2022,1,16);
            account.Histories.Add(new StatementLog(1000, logDate, 1500, LogType.Deposit));
            account.Histories.Add(new StatementLog(200, logDate, 1300, LogType.Withdraw));
            //account.Deposit(1000);
            //account.Withdraw(200);
            var statement = account.PrintStatement(); 

            var stringReader = new StringReader(statement);
            Console.SetIn(stringReader);

            var actual = string.Empty;
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                actual += line+"\n"; 
            }

            if (actual.Length > 0)
                actual= actual.Substring(0, actual.Length - 1);
            Assert.AreEqual(expected, actual);
        }
    }
}
