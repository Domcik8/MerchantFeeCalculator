using System;

namespace Domain
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string MerchantName { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }

        public Transaction(DateTime date, string merchantName, decimal amount)
        {
            Date = date;
            MerchantName = merchantName;
            Amount = amount;
        }
    }
}
