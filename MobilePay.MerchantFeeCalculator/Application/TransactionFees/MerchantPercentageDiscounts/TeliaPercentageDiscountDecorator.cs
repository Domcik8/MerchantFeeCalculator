using Application.TransactionFees.Base;
using Application.TransactionFees.MerchantPercentageDiscounts.Base;

namespace Application.TransactionFees.MerchantPercentageDiscounts
{
    /// <summary>
    /// Add transaction fee percentage discount for Telia.
    /// </summary>
    public class TeliaPercentageDiscountDecorator : BaseMerchantPercentageDiscountDecorator
    {
        private const string TeliaMerchantName = "TELIA";
        private const decimal TeliaFeeDiscountPercentage = 0.1m;

        public TeliaPercentageDiscountDecorator(
            BaseTransactionFeeService transactionFeeService)
            : base(transactionFeeService, TeliaMerchantName, TeliaFeeDiscountPercentage) { }
    }
}
