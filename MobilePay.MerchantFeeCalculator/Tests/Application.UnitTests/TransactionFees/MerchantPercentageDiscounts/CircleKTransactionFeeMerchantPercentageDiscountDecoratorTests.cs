using Application.TransactionFees.Components;
using Application.TransactionFees.Decorators.MerchantPercentageDiscounts;
using Domain;
using FluentAssertions;
using Xunit;

namespace Application.UnitTests.TransactionFees.MerchantPercentageDiscounts
{
    public class CircleKTransactionFeeMerchantPercentageDiscountDecoratorTests
    {
        [Theory]
        [InlineData("CIRCLE_K", 120, 0.96)]
        [InlineData("CIRCLE_K", 200, 1.60)]
        [InlineData("CIRCLE_K", 300, 2.40)]
        [InlineData("CIRCLE_K", 150, 1.20)]
        public void CalculateMerchantFee_ForCircleKTransaction_ShouldApplyDiscount(
            string merchantName, decimal amount, decimal expected)
        {
            // Arrange
            var transaction = new Transaction { MerchantName = merchantName, Amount = amount };
            var transactionFeeService = new TransactionPercentageFeeService();
            var sut = new CircleKPercentageDiscountDecorator(transactionFeeService);

            // Act
            sut.CalculateMerchantFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }
    }
}
