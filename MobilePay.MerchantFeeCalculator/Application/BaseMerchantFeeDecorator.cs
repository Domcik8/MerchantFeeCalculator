using Domain;

namespace Application.TransactionFees.MerchantPercentageDiscounts
{
    public abstract class BaseMerchantFeeDecorator : BaseMerchantFeeService
    {
        protected BaseMerchantFeeService _transactionFeeService;

        public BaseMerchantFeeDecorator(BaseMerchantFeeService transactionFeeService)
        {
            _transactionFeeService = transactionFeeService;
        }

        public override void CalculateMerchantFee(Transaction transaction)
        {
            if (_transactionFeeService != null)
            {
                _transactionFeeService.CalculateMerchantFee(transaction);
            }
        }
    }
}
