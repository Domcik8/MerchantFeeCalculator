using Application.TransactionFees;
using Domain;

namespace Application.UnitTests.TransactionFees.MerchantPercentageDiscounts
{
    public class ConcreteTransactionFeeService : BaseTransactionFeeService
    {
        public override void CalculateTransactionFee(Transaction transaction) { }
    }
}
