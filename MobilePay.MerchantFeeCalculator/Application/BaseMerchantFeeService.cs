using Domain;

namespace Application
{
    public abstract class BaseMerchantFeeService
    {
        public abstract void CalculateMerchantFee(Transaction transaction);
    }
}
