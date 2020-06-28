using Domain.Models;
using Domain.TransactionFees.Base;

namespace Domain.TransactionFees.Types
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
