using Domain;

namespace Application.TransactionFeeServiceDiscountDecorator
{
    public abstract class BaseTransactionFeeServiceDiscountDecorator : BaseTransactionFeeService
    {
        protected BaseTransactionFeeService _transactionFeeService;

        public BaseTransactionFeeServiceDiscountDecorator(BaseTransactionFeeService transactionFeeService)
        {
            _transactionFeeService = transactionFeeService;
        }

        public override void CalculateTransactionFee(Transaction transaction)
        {
            if (_transactionFeeService != null)
            {
                _transactionFeeService.CalculateTransactionFee(transaction);
            }
        }
    }
}
