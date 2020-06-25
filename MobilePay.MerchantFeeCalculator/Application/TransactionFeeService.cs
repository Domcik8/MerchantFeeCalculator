using Domain;

namespace Application
{
    public class TransactionFeeService : ITransactionFeeService
    {
        public const decimal TransactionFee = 0.01m;

        public void CalculateTransactionFee(Transaction transaction)
        {
            transaction.Fee = transaction.Amount * TransactionFee;
        }
    }
}
