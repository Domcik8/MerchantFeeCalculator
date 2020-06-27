using Application;
using Application.InvoiceFees;
using Application.InvoiceFees.Components;
using Application.InvoiceFees.Decorators;
using Application.TransactionFees;
using Application.TransactionFees.Components;
using Application.TransactionFees.Decorators.MerchantPercentageDiscounts;
using Application.TransactionFees.MerchantPercentageDiscounts;
using Infrastructure;

namespace Api
{
    public class MerchantFeeCalculator
    {
        public void CalculateFees()
        {
            var transactionRepository = new TxtTransactionRepository();

            BaseTransactionFeeService transactionFeeService = new TransactionPercentageFeeService();
            transactionFeeService = new TeliaPercentageDiscountDecorator(transactionFeeService);
            transactionFeeService = new CircleKPercentageDiscountDecorator(transactionFeeService);

            BaseInvoiceFeeService invoiceFeeService = new InvoiceFixedFeeService();
            invoiceFeeService = new FirstMonthlyInvoiceFixedFeeDecorator(invoiceFeeService);
            invoiceFeeService = new FreeFeeInvoiceFixedFeeDecorator(invoiceFeeService);
            
            var merchantFeeCalculator =
                new MerchantFeeCalculatorService(transactionRepository, transactionFeeService, invoiceFeeService);

            merchantFeeCalculator.CalculateFees();
        }
    }
}
