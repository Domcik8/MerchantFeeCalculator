using Domain.InvoiceFees.Base;

namespace Domain.UnitTests.InvoiceFees.Rules
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
