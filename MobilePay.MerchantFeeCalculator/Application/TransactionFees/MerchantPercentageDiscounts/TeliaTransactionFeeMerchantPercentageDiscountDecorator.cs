using Application.TransactionFees.MerchantPercentageDiscounts.Base;

namespace Application.TransactionFees.MerchantPercentageDiscounts
{
    public class TeliaTransactionFeeMerchantPercentageDiscountDecorator : BaseTransactionFeeMerchantPercentageDiscountDecorator
    {
        private const string TeliaMerchantName = "TELIA";
        private const decimal TeliaFeeDiscountPercentage = 0.1m;

        public TeliaTransactionFeeMerchantPercentageDiscountDecorator(BaseMerchantFeeService transactionFeeService)
            : base(transactionFeeService, TeliaMerchantName, TeliaFeeDiscountPercentage) { }
    }
}
