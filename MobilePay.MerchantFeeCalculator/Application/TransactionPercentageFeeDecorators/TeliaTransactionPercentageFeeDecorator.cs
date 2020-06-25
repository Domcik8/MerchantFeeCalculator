using Domain;

namespace Application.TransactionPercentageFeeDecorators
{
    public class TeliaTransactionPercentageFeeDecorator : BaseTransactionFeeServiceDiscountDecorator
    {
        public const decimal TeliaTransactionPercantageFeeDiscount = 0.1m;

        public TeliaTransactionPercentageFeeDecorator(BaseTransactionFeeService transactionFeeService)
            : base(transactionFeeService) { }

        public override void CalculateTransactionFee(Transaction transaction)
        {
            base.CalculateTransactionFee(transaction);

            if (transaction.MerchantName == "TELIA")
                transaction.Fee *= 1 - TeliaTransactionPercantageFeeDiscount;
        }
    }
}
