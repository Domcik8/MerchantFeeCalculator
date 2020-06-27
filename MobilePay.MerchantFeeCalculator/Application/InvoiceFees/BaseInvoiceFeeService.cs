using Domain;

namespace Application.InvoiceFees
{
    public abstract class BaseInvoiceFeeService
    {
        public abstract void CalculateInvoiceFee(Transaction transaction);
    }
}
