using Domain;

namespace Application
{
    public class TransactionPercentageFeeService : BaseTransactionFeeService
    {
        public const decimal StandardTransactionPercentageFee = 0.01m;

        public override void CalculateTransactionFee(Transaction transaction)
        {
            CalculateStandardTransactionPercentageFee(transaction);
        }

        public void CalculateStandardTransactionPercentageFee(Transaction transaction)
        {
            transaction.Fee = transaction.Amount * StandardTransactionPercentageFee;
        }
    }
}
