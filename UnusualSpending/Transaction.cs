using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnusualSpending
{
    public class Transaction
    { 
        public int CurrentMonth { get; set; }
        public List<Payment> Payments { get; set; }

        public Transaction(int currentMonth)
        {
            CurrentMonth = currentMonth;
            Payments = new List<Payment>();
        }

        public void AddPayment(int userId,int price, DateTime transActionDate, Category category)
        {
            Payments.Add(new Payment(userId,price, transActionDate, category));
        }

        public string UnusuallyHigh(int userId)
        {
            var previousMonth = CurrentMonth == 1 ? 12 : CurrentMonth - 1;
            var paymentDetails = Payments.Where(w => w.UserId == userId &&
                (w.TransActionDate.Month == CurrentMonth || w.TransActionDate.Month == previousMonth))
                .GroupBy(s => new { s.Category })
                .Select(g =>
                            new
                            {
                                Category = g.Key.Category, 
                                SumCurrent = g.Where(x=>x.TransActionDate.Month==CurrentMonth).Sum(x => x.Price),
                                SumPrevious = g.Where(x => x.TransActionDate.Month == previousMonth).Sum(x => x.Price)
                            }
                        );
             var result= paymentDetails.Where(w => w.SumPrevious != 0 && (w.SumCurrent / w.SumPrevious) > 1.5)
                .Select(s => new PaymentResult { Category = s.Category, Total = s.SumCurrent - s.SumPrevious })
                .ToList();
            string context = string.Empty;
            if(result.Count>0)
            {
                context += "Hello card user!\nWe have detected unusually high spending on your card in these categories:\n";
                foreach (var item in result)
                {
                    context += $"*You spent ${item.Total} on {item.Category}\n";
                }
                context += "Love,\nThe Credit Card Company";
            }
            return context; 
        }
         
    }
}
