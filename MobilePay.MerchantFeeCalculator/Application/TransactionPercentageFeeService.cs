using Domain;

namespace Application
{
    public class TransactionPercentageFeeService : ITransactionFeeService
    {
        public const decimal StandardTransactionPercentageFee = 0.01m;
        public const decimal TeliaTransactionPercantageFeeDiscount = 0.1m;
        public const decimal CircleKTransactionPercantageFeeDiscount = 0.2m;

        public decimal CalculateTransactionFee(Transaction transaction)
        {
            var fee = CalculateStandardTransactionFee(transaction);

            if (transaction.MerchantName == "TELIA")
                fee *= (1 - TeliaTransactionPercantageFeeDiscount);

            if (transaction.MerchantName == "CIRCLE_K")
                fee *= (1 - CircleKTransactionPercantageFeeDiscount);

            return fee;
        }

        public decimal CalculateStandardTransactionFee(Transaction transaction)
            => transaction.Amount * StandardTransactionPercentageFee;
    }
}
