using Domain;

namespace Application.TransactionFees.MerchantPercentageDiscounts.Base
{
    public abstract class BaseTransactionFeeMerchantPercentageDiscountDecorator
        : BaseMerchantFeeDecorator
    {
        protected string MerchantName { get; }
        protected decimal FeeDiscountPercentage { get; }

        public BaseTransactionFeeMerchantPercentageDiscountDecorator(
            BaseMerchantFeeService merchantFeeService, string merchantName, decimal feeDiscountPercentage)
            : base(merchantFeeService)
        {
            MerchantName = merchantName;
            FeeDiscountPercentage = feeDiscountPercentage;
        }

        public override void CalculateMerchantFee(Transaction transaction)
        {
            base.CalculateMerchantFee(transaction);
            ApplyMerchantDiscount(transaction);
        }

        private void ApplyMerchantDiscount(Transaction transaction)
        {
            if (transaction.MerchantName == MerchantName)
                transaction.Fee *= 1 - FeeDiscountPercentage;
        }
    }
}
