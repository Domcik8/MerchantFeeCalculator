using Domain;

namespace Application.TransactionFees
{
    public abstract class BaseTransactionFeeService
    {
        public abstract void CalculateTransactionFee(Transaction transaction);
    }
}
