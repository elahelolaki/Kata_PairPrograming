using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public class StatementLog
    {
        public int Amount { get; set; }

        public DateTime LogDate { get; set; }

        public int Balance { get; set; }

        public LogType LogType { get; set; }
        public StatementLog(int amount, DateTime logDate,int Balance, LogType logType)
        {
            this.Amount = amount;
            this.LogDate = logDate;
            this.Balance = Balance;
            this.LogType = logType;
        }

        public string FormatShowDate()
        {
            return LogDate.ToString("dd/MM/yyyy");
        }

        public string FormatShowAmount()
        {
            return (LogType == LogType.Deposit) ? Amount.ToString() : "-" + Amount.ToString();
        }
    }
}
