using System;

namespace Domain
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string MerchantName { get; set; }
        public string Amount { get; set; }
        public string Fee { get; set; }

        public Transaction(DateTime date, string merchantName, string amount)
        {
            Date = date;
            MerchantName = merchantName;
            Amount = amount;
        }
    }
}
