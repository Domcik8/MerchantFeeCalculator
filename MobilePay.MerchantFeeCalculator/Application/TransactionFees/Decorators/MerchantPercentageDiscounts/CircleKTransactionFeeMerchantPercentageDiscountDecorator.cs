using Application.TransactionFees.Decorators.MerchantPercentageDiscounts.Base;

namespace Application.TransactionFees.Decorators.MerchantPercentageDiscounts
{
    public class CircleKTransactionFeeMerchantPercentageDiscountDecorator
        : BaseTransactionFeeMerchantPercentageDiscountDecorator
    {
        private const string CircleKMerchantName = "CIRCLE_K";
        private const decimal CircleKFeeDiscountPercentage = 0.2m;

        public CircleKTransactionFeeMerchantPercentageDiscountDecorator(
            BaseTransactionFeeService transactionFeeService)
            : base(transactionFeeService, CircleKMerchantName, CircleKFeeDiscountPercentage) { }
    }
}
