using Domain;

namespace Application
{
    public interface ITransactionFeeService
    {
        /// <summary>
        /// Calculate trancation fee with discounts.
        /// </summary>
        public decimal CalculateTransactionFee(Transaction transaction);

        /// <summary>
        /// Calculate transaction fee without discounts.
        /// </summary>
        public decimal CalculateStandardTransactionFee(Transaction transaction);
    }
}
