namespace Application.TransactionFeeServiceDiscountDecorator.MerchantPercentageDiscountDecorator
{
    public class CircleKTransactionPercentageFeeDecorator : BaseTransactionFeeServiceMerchantPercentageDiscountDecorator
    {
        private const string CircleKMerchantName = "CIRCLE_K";
        private const decimal CircleKFeeDiscountPercentage = 0.2m;

        public CircleKTransactionPercentageFeeDecorator(BaseTransactionFeeService transactionFeeService)
            : base(transactionFeeService, CircleKMerchantName, CircleKFeeDiscountPercentage) { }
    }
}
