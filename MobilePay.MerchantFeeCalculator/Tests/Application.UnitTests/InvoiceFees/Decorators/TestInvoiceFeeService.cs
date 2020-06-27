using Domain;

namespace Application.InvoiceFees.Components
{
    public class TestInvoiceFeeService : BaseInvoiceFeeService
    {
        public const decimal StandardInvoiceFixedFee = 1;

        public override void CalculateInvoiceFee(Transaction transaction)
        {
            transaction.Fee += StandardInvoiceFixedFee;
        }
    }
}
