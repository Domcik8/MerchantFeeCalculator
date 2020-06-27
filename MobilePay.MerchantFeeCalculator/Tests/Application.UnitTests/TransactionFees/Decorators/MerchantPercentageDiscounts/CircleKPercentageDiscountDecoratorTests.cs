using Application.TransactionFees.Decorators.MerchantPercentageDiscounts;
using Domain;
using FluentAssertions;
using Xunit;

namespace Application.UnitTests.TransactionFees.MerchantPercentageDiscounts
{
    public class CircleKPercentageDiscountDecoratorTests
    {
        [Theory]
        [InlineData("CIRCLE_K", 1.20, 0.96)]
        [InlineData("CIRCLE_K", 2.00, 1.60)]
        [InlineData("CIRCLE_K", 3.00, 2.40)]
        [InlineData("CIRCLE_K", 1.50, 1.20)]
        public void CalculateMerchantFee_ForCircleKTransaction_ShouldApplyDiscount(
            string merchantName, decimal fee, decimal expected)
        {
            // Arrange
            var transaction = new Transaction { MerchantName = merchantName, Fee = fee };
            var transactionFeeService = new TestTransactionFeeService();
            var sut = new CircleKPercentageDiscountDecorator(transactionFeeService);

            // Act
            sut.CalculateTransactionFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("TELIA", 1.20, 1.20)]
        [InlineData("7-ELEVEN", 2.00, 2.00)]
        [InlineData("NETTO", 3.00, 3.00)]
        [InlineData("TELIA", 1.50, 1.50)]
        public void CalculateMerchantFee_ForNonCircleKTransaction_ShouldNotApplyDiscount(
            string merchantName, decimal fee, decimal expected)
        {
            // Arrange
            var transaction = new Transaction { MerchantName = merchantName, Fee = fee };
            var transactionFeeService = new TestTransactionFeeService();
            var sut = new CircleKPercentageDiscountDecorator(transactionFeeService);

            // Act
            sut.CalculateTransactionFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }
    }
}
