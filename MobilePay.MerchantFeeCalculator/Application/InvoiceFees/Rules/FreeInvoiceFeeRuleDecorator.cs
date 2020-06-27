using Application.InvoiceFees.Base;
using Domain;

namespace Application.InvoiceFees.Rules
{
    /// <summary>
    /// Exclude invoice fee for transactions without a fee.
    /// </summary>
    public class FreeInvoiceFeeRuleDecorator : BaseInvoiceFeeDecorator
    {
        public FreeInvoiceFeeRuleDecorator(BaseInvoiceFeeService invoiceFeeService) : base(invoiceFeeService) { }

        public override void CalculateInvoiceFee(Transaction transaction)
        {
            if (IsFreeTransaction(transaction))
                return;

            base.CalculateInvoiceFee(transaction);
        }

        private bool IsFreeTransaction(Transaction transaction)
        {
            return transaction.Fee <= 0;
        }
    }
}