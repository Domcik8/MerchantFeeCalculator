using Application.TransactionFees.MerchantPercentageDiscounts;
using Domain;

namespace Application.InvoiceFees.Rules
{
    /// <summary>
    /// Exclude invoice fee for transactions without a fee.
    /// </summary>
    public class FreeFeeInvoiceFixedFeeDecorator : BaseMerchantFeeDecorator
    {
        public FreeFeeInvoiceFixedFeeDecorator(BaseMerchantFeeService transactionFeeService)
            : base(transactionFeeService) { }

        public override void CalculateMerchantFee(Transaction transaction)
        {
            if (IsFreeTransaction(transaction))
                return;

            base.CalculateMerchantFee(transaction);
        }

        private bool IsFreeTransaction(Transaction transaction)
        {
            return transaction.Fee <= 0;
        }
    }
}