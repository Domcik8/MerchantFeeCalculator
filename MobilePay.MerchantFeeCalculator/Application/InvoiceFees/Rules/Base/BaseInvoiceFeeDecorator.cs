using Domain;

namespace Application.TransactionFees.MerchantPercentageDiscounts.Base
{
    public abstract class BaseInvoiceFeeDecorator : BaseMerchantFeeDecorator
    {
        public BaseInvoiceFeeDecorator(BaseMerchantFeeService transactionFeeService)
            : base(transactionFeeService) { }

        public override void CalculateMerchantFee(Transaction transaction)
        {
            base.CalculateMerchantFee(transaction);
        }
    }
}
