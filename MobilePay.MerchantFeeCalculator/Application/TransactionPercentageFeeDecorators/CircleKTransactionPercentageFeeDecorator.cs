using Domain;

namespace Application.TransactionPercentageFeeDecorators
{
    public class CircleKTransactionPercentageFeeDecorator : BaseTransactionFeeServiceDiscountDecorator
    {
        public const decimal CircleKTransactionPercantageFeeDiscount = 0.2m;

        public CircleKTransactionPercentageFeeDecorator(BaseTransactionFeeService transactionFeeService)
            : base(transactionFeeService) { }

        public override void CalculateTransactionFee(Transaction transaction)
        {
            base.CalculateTransactionFee(transaction);

            if (transaction.MerchantName == "CIRCLE_K")
                transaction.Fee *= 1 - CircleKTransactionPercantageFeeDiscount;
        }
    }
}
