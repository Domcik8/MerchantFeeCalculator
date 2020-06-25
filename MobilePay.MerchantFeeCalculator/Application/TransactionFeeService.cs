using Domain;

namespace Application
{
    public class TransactionFeeService : ITransactionFeeService
    {
        public const decimal TransactionFee = 0.01m;

        public decimal CalculateTransactionFee(Transaction transaction)
            => transaction.Amount * TransactionFee;
    }
}
