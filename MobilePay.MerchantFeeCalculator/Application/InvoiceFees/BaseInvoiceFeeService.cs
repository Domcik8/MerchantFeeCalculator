using Domain;

namespace Application.InvoiceFees
{
    public abstract class BaseInvoiceFeeService : BaseMerchantFeeService
    {
        public override void CalculateMerchantFee(Transaction transaction)
        {
            CalculateInvoiceFee(transaction);
        }

        public abstract void CalculateInvoiceFee(Transaction transaction);
    }
}
