using Application.TransactionFees.MerchantPercentageDiscounts.Base;

namespace Application.TransactionFees.MerchantPercentageDiscounts
{
    public class CircleKTransactionFeeMerchantPercentageDiscountDecorator : BaseTransactionFeeMerchantPercentageDiscountDecorator
    {
        private const string CircleKMerchantName = "CIRCLE_K";
        private const decimal CircleKFeeDiscountPercentage = 0.2m;

        public CircleKTransactionFeeMerchantPercentageDiscountDecorator(BaseMerchantFeeService transactionFeeService)
            : base(transactionFeeService, CircleKMerchantName, CircleKFeeDiscountPercentage) { }
    }
}
