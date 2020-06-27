using Application.InvoiceFees.Base;
using Domain;

namespace Application.UnitTests.InvoiceFees.Rules
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
