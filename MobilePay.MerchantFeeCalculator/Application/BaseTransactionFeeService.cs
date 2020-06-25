using Domain;

namespace Application
{
    public abstract class BaseTransactionFeeService
    {
        public abstract void CalculateTransactionFee(Transaction transaction);
    }
}
