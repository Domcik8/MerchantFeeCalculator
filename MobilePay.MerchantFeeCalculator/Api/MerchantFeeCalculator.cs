using Application;
using Application.InvoiceFees.Base;
using Application.InvoiceFees.Rules;
using Application.InvoiceFees.Types;
using Application.TransactionFees.Base;
using Application.TransactionFees.MerchantPercentageDiscounts;
using Application.TransactionFees.Types;
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
            invoiceFeeService = new FirstMonthlyInvoiceFeeRuleDecorator(invoiceFeeService);
            invoiceFeeService = new FreeInvoiceFeeRuleDecorator(invoiceFeeService);
            
            var merchantFeeCalculator =
                new MerchantFeeCalculatorService(transactionRepository, transactionFeeService, invoiceFeeService);

            merchantFeeCalculator.CalculateFees();
        }
    }
}
