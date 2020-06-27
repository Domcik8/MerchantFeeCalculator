using Domain;

namespace Application.InvoiceFees.Components
{
    /// <summary>
    /// Add invoice fixed fee per transaction.
    /// </summary>
    public class InvoiceFixedFeeService : BaseInvoiceFeeService
    {
        public const decimal StandardInvoiceFixedFee = 29;

        public override void CalculateInvoiceFee(Transaction transaction)
        {
            transaction.Fee += StandardInvoiceFixedFee;
        }
    }
}
