using Domain;

namespace Application
{
    public class TransactionFeeService : ITransactionFeeService
    {
        public const decimal StandardTransactionFeePercentage = 0.01m;

        public decimal CalculateTransactionFee(Transaction transaction)
        {
            var standardfee = CalculateStandardTransactionFee(transaction);

            return standardfee;
        }

        public decimal CalculateStandardTransactionFee(Transaction transaction)
            => transaction.Amount * StandardTransactionFeePercentage;
    }
}
