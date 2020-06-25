using Domain;

namespace Application.TransactionFees
{
    public class TransactionPercentageFeeService : BaseMerchantFeeService
    {
        public const decimal StandardTransactionPercentageFee = 0.01m;

        public override void CalculateMerchantFee(Transaction transaction)
        {
            CalculateStandardTransactionPercentageFee(transaction);
        }

        public void CalculateStandardTransactionPercentageFee(Transaction transaction)
        {
            transaction.Fee = transaction.Amount * StandardTransactionPercentageFee;
        }
    }
}
