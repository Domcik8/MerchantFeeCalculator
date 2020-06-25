using System;

namespace Domain
{
    class Transaction
    {
        public DateTime Date { get; set; }
        public string MerchantName { get; set; }
        public string Amount { get; set; }
        public string Fee { get; set; }
    }
}
