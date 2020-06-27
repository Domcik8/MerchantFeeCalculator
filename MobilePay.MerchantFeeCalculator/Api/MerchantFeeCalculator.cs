using Application;
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
            //var transactionRepository = new TxtTransactionRepository();
            //BaseMerchantFeeService merchantFeeService = new TransactionPercentageFeeService();
            //merchantFeeService = new TeliaPercentageDiscountDecorator(merchantFeeService);
            //merchantFeeService = new CircleKPercentageDiscountDecorator(merchantFeeService);



            //var merchantFeeCalculator = new MerchantFeeCalculatorService(transactionRepository, merchantFeeService);
            //merchantFeeCalculator.CalculateFees();
        }
    }
}
