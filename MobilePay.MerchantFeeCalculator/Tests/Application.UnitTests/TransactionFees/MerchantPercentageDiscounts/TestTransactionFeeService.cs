using Application.TransactionFees.Base;
using Domain;

namespace Application.UnitTests.TransactionFees.MerchantPercentageDiscounts
{
    public class TestTransactionFeeService : BaseTransactionFeeService
    {
        public override void CalculateTransactionFee(Transaction transaction) { }
    }
}
