namespace Domain.InvoiceFees.Base
{
    public abstract class BaseInvoiceFeeDecorator : BaseInvoiceFeeService
    {
        protected BaseInvoiceFeeService _invoiceFeeService;

        public BaseInvoiceFeeDecorator(BaseInvoiceFeeService invoiceFeeService)
        {
            _invoiceFeeService = invoiceFeeService;
        }

        public override void CalculateInvoiceFee(Transaction transaction)
        {
            if (_invoiceFeeService != null)
            {
                _invoiceFeeService.CalculateInvoiceFee(transaction);
            }
        }
    }
}
