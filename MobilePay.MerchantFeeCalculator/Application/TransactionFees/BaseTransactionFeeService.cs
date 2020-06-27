using Domain;

namespace Application.TransactionFees
{
    public abstract class BaseTransactionFeeService : BaseMerchantFeeService
    {
        public override void CalculateMerchantFee(Transaction transaction)
        {
            CalculateTransactionFee(transaction);
        }

        public abstract void CalculateTransactionFee(Transaction transaction);
    }
}
