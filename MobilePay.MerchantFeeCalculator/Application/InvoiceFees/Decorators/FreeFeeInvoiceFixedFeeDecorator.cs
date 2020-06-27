using Domain;

namespace Application.InvoiceFees.Decorators
{
    /// <summary>
    /// Exclude invoice fee for transactions without a fee.
    /// </summary>
    public class FreeFeeInvoiceFixedFeeDecorator : BaseInvoiceFeeDecorator
    {
        public FreeFeeInvoiceFixedFeeDecorator(BaseInvoiceFeeService invoiceFeeService) : base(invoiceFeeService) { }

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