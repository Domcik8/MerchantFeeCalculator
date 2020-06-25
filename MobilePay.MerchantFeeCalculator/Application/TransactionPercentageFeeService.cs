using Domain;

namespace Application
{
    public class TransactionPercentageFeeService : ITransactionFeeService
    {
        public const decimal StandardTransactionPercentageFee = 0.01m;
        public const decimal TeliaTransactionPercantageFeeDiscount = 0.1m;

        public decimal CalculateTransactionFee(Transaction transaction)
        {
            var standardfee = CalculateStandardTransactionFee(transaction);
      
            return standardfee;
        }

        public decimal CalculateStandardTransactionFee(Transaction transaction)
            => transaction.Amount * StandardTransactionPercentageFee;
    }
}
