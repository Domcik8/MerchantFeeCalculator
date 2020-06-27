using Domain;

namespace Application.InvoiceFees.Components
{
    public class InvoiceFixedFeeService : BaseInvoiceFeeService
    {
        public const decimal StandardInvoiceFixedFee = 29;

        public override void CalculateInvoiceFee(Transaction transaction)
        {
            transaction.Fee += StandardInvoiceFixedFee;
        }
    }
}
