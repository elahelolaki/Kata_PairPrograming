using System;

namespace UnusualSpending
{
    public class Payment
    {
        public int UserId { get; set; }
        public int Price { get; set; }

        public DateTime TransActionDate { get; set; }

        public Category Category { get; set; }

        public Payment(int userId, int price,DateTime transActionDate, Category category)
        {
            UserId = userId;
            Price = price;
            TransActionDate = transActionDate;
            Category = category;
        }
    }
}
