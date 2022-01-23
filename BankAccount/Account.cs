using System;
using System.Collections.Generic;

namespace BankAccount
{
    public  class Account
    {
        public int Balance { get; set; }
        public List<StatementLog> Histories { get; set; }

        public  Account(int initialBalance)
        {
            this.Balance = initialBalance;
            this.Histories = new List<StatementLog>();
        }

        public void Deposit(int amount)
        {
            Balance += amount;
            Histories.Add(new StatementLog(amount, DateTime.Now, Balance,LogType.Deposit));
        }

        public void Withdraw(int amount)
        {
            Balance -= amount;
            Histories.Add(new StatementLog(-amount, DateTime.Now, Balance,LogType.Withdraw));
        }

        public string PrintStatement()
        {
            string statements = string.Empty;
            string headings = "Date \t Amount \t Balance";
            statements += headings;
            foreach (StatementLog item in Histories)
            {
                statements += $"\n{item.FormatShowDate()} \t {item.FormatShowAmount()} \t {item.Balance}";
            }
            return statements;
        }
         
    }
}
