using Domain;

namespace Application.InvoiceFees.Base
{
    public abstract class BaseInvoiceFeeService
    {
        public abstract void CalculateInvoiceFee(Transaction transaction);
    }
}
