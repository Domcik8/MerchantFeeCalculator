using Domain;

namespace Application.TransactionFeeServiceDiscountDecorator.MerchantPercentageDiscountDecorator
{
    public abstract class BaseTransactionFeeServiceMerchantPercentageDiscountDecorator
        : BaseTransactionFeeServiceDiscountDecorator
    {
        protected string MerchantName { get; }
        protected decimal FeeDiscountPercentage { get; }

        public BaseTransactionFeeServiceMerchantPercentageDiscountDecorator(
            BaseTransactionFeeService transactionFeeService, string merchantName, decimal feeDiscountPercentage)
            : base(transactionFeeService)
        {
            MerchantName = merchantName;
            FeeDiscountPercentage = feeDiscountPercentage;
        }

        public override void CalculateTransactionFee(Transaction transaction)
        {
            base.CalculateTransactionFee(transaction);

            if (transaction.MerchantName == MerchantName)
                transaction.Fee *= 1 - FeeDiscountPercentage;
        }
    }
}
