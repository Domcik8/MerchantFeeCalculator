using Application.TransactionFees.Base;
using Domain;

namespace Application.TransactionFees.Types
{
    /// <summary>
    /// Add percentage fee per transaction.
    /// </summary>
    public class TransactionPercentageFeeService : BaseTransactionFeeService
    {
        public const decimal StandardTransactionPercentageFee = 0.01m;

        public override void CalculateTransactionFee(Transaction transaction)
        {
            transaction.Fee = transaction.Amount * StandardTransactionPercentageFee;
        }
    }
}
