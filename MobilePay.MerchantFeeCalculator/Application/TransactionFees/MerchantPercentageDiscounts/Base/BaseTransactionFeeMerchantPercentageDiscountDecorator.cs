using Domain;

namespace Application.TransactionFees.MerchantPercentageDiscounts.Base
{
    public abstract class BaseTransactionFeeMerchantPercentageDiscountDecorator
        : BaseMerchantFeeDecorator
    {
        protected string MerchantName { get; }
        protected decimal FeeDiscountPercentage { get; }

        public BaseTransactionFeeMerchantPercentageDiscountDecorator(
            BaseMerchantFeeService transactionFeeService, string merchantName, decimal feeDiscountPercentage)
            : base(transactionFeeService)
        {
            MerchantName = merchantName;
            FeeDiscountPercentage = feeDiscountPercentage;
        }

        public override void CalculateMerchantFee(Transaction transaction)
        {
            base.CalculateMerchantFee(transaction);
            ApplyMerchantDiscount(transaction);
        }

        public void ApplyMerchantDiscount(Transaction transaction)
        {
            if (transaction.MerchantName == MerchantName)
                transaction.Fee *= 1 - FeeDiscountPercentage;
        }
    }
}
