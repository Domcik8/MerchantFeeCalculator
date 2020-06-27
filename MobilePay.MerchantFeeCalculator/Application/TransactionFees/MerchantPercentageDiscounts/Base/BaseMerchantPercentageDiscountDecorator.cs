using Application.TransactionFees.Base;
using Domain;

namespace Application.TransactionFees.MerchantPercentageDiscounts.Base
{
    public abstract class BaseMerchantPercentageDiscountDecorator : BaseTransactionFeeDecorator
    {
        protected string MerchantName { get; }
        protected decimal FeeDiscountPercentage { get; }

        public BaseMerchantPercentageDiscountDecorator(
            BaseTransactionFeeService transactionFeeService, string merchantName, decimal feeDiscountPercentage)
            : base(transactionFeeService)
        {
            MerchantName = merchantName;
            FeeDiscountPercentage = feeDiscountPercentage;
        }

        public override void CalculateTransactionFee(Transaction transaction)
        {
            base.CalculateTransactionFee(transaction);
            ApplyMerchantDiscount(transaction);
        }

        private void ApplyMerchantDiscount(Transaction transaction)
        {
            if (transaction.MerchantName == MerchantName)
                transaction.Fee *= 1 - FeeDiscountPercentage;
        }
    }
}
