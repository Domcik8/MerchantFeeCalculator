using Domain.Models;

namespace Domain.InvoiceFees.Base
{
    public abstract class BaseInvoiceFeeService
    {
        public abstract void CalculateInvoiceFee(Transaction transaction);
    }
}
