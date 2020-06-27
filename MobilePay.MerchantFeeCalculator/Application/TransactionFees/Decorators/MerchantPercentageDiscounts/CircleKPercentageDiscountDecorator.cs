using Application.TransactionFees.Decorators.MerchantPercentageDiscounts.Base;

namespace Application.TransactionFees.Decorators.MerchantPercentageDiscounts
{
    public class CircleKPercentageDiscountDecorator : BaseMerchantPercentageDiscountDecorator
    {
        private const string CircleKMerchantName = "CIRCLE_K";
        private const decimal CircleKFeeDiscountPercentage = 0.2m;

        public CircleKPercentageDiscountDecorator( BaseTransactionFeeService transactionFeeService)
            : base(transactionFeeService, CircleKMerchantName, CircleKFeeDiscountPercentage) { }
    }
}
