using Domain;

namespace Application.TransactionFees.MerchantPercentageDiscounts
{
    public abstract class BaseMerchantFeeDecorator : BaseMerchantFeeService
    {
        protected BaseMerchantFeeService _merchantFeeService;

        public BaseMerchantFeeDecorator(BaseMerchantFeeService merchantFeeService)
        {
            _merchantFeeService = merchantFeeService;
        }

        public override void CalculateMerchantFee(Transaction transaction)
        {
            if (_merchantFeeService != null)
            {
                _merchantFeeService.CalculateMerchantFee(transaction);
            }
        }
    }
}
