using Application.TransactionFees.MerchantPercentageDiscounts;
using Domain;
using FluentAssertions;
using Xunit;

namespace Application.UnitTests.TransactionFees.MerchantPercentageDiscounts
{
    public class TeliaPercentageDiscountDecoratorTests
    {
        [Theory]
        [InlineData("TELIA", 1.20, 1.08)]
        [InlineData("TELIA", 2.00, 1.80)]
        [InlineData("TELIA", 3.00, 2.70)]
        [InlineData("TELIA", 1.50, 1.35)]
        public void CalculateMerchantFee_ForTeliaTransaction_ShouldApplyDiscount(
            string merchantName, decimal fee, decimal expected)
        {
            // Arrange
            var transaction = new Transaction { MerchantName = merchantName, Fee = fee };
            var transactionFeeService = new TestTransactionFeeService();
            var sut = new TeliaPercentageDiscountDecorator(transactionFeeService);

            // Act
            sut.CalculateTransactionFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("CIRCLE_K", 1.20, 1.20)]
        [InlineData("7-ELEVEN", 2.00, 2.00)]
        [InlineData("NETTO", 3.00, 3.00)]
        [InlineData("CIRCLE_K", 1.50, 1.50)]
        public void CalculateMerchantFee_ForNonTeliaTransaction_ShouldNotApplyDiscount(
            string merchantName, decimal fee, decimal expected)
        {
            // Arrange
            var transaction = new Transaction { MerchantName = merchantName, Fee = fee };
            var transactionFeeService = new TestTransactionFeeService();
            var sut = new TeliaPercentageDiscountDecorator(transactionFeeService);

            // Act
            sut.CalculateTransactionFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }
    }
}
