using Application.TransactionFees.Components;
using Application.TransactionFees.MerchantPercentageDiscounts;
using Domain;
using FluentAssertions;
using Xunit;

namespace Application.UnitTests.TransactionFees.MerchantPercentageDiscounts
{
    public class TeliaTransactionFeeMerchantPercentageDiscountDecoratorTests
    {
        [Theory]
        [InlineData("TELIA", 120, 1.08)]
        [InlineData("TELIA", 200, 1.80)]
        [InlineData("TELIA", 300, 2.70)]
        [InlineData("TELIA", 150, 1.35)]
        public void CalculateMerchantFee_ForTeliaTransaction_ShouldApplyDiscount(
            string merchantName, decimal amount, decimal expected)
        {
            // Arrange
            var transaction = new Transaction { MerchantName = merchantName, Amount = amount };
            var transactionFeeService = new TransactionPercentageFeeService();
            var sut = new TeliaTransactionFeeMerchantPercentageDiscountDecorator(transactionFeeService);

            // Act
            sut.CalculateMerchantFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }
    }
}
