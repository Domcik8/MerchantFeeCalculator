using Domain;

namespace Application
{
    public interface ITransactionFeeService
    {
        public decimal CalculateTransactionFee(Transaction transaction);
    }
}
