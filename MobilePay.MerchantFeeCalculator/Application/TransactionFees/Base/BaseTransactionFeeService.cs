using Domain;

namespace Application.TransactionFees.Base
{
    public abstract class BaseTransactionFeeService
    {
        public abstract void CalculateTransactionFee(Transaction transaction);
    }
}
