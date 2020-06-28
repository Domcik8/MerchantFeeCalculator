using Domain.Models;

namespace Domain.TransactionFees.Base
{
    public abstract class BaseTransactionFeeDecorator : BaseTransactionFeeService
    {
        protected BaseTransactionFeeService _transactionFeeService;

        public BaseTransactionFeeDecorator(BaseTransactionFeeService transactionFeeService)
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
