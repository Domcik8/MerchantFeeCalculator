namespace Application.TransactionFeeServiceDiscountDecorator.MerchantPercentageDiscountDecorator
{
    public class TeliaTransactionPercentageFeeDecorator : BaseTransactionFeeServiceMerchantPercentageDiscountDecorator
    {
        private const string TeliaMerchantName = "TELIA";
        private const decimal TeliaFeeDiscountPercentage = 0.1m;

        public TeliaTransactionPercentageFeeDecorator(BaseTransactionFeeService transactionFeeService)
            : base(transactionFeeService, TeliaMerchantName, TeliaFeeDiscountPercentage) { }
    }
}
