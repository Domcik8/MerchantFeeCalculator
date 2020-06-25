using Domain;

namespace Application
{
    public interface ITransactionFeeService
    {
        public void CalculateTransactionFee(Transaction transaction);
    }
}
