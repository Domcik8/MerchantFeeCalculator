using Application.TransactionFees;
using Application.TransactionFees.MerchantPercentageDiscounts;
using Domain;
using FluentAssertions;
using Xunit;

namespace Application.UnitTests
{
    public class TransactionPercentageFeeServiceTests
    {
        [Theory]
        [InlineData("CIRCLE_K", 120, 1.20)]
        [InlineData("TELIA", 200, 2.00)]
        [InlineData("CIRCLE_K", 300, 3.00)]
        [InlineData("CIRCLE_K", 150, 1.50)]
        public void CalculateMerchantFee_ForAnyTransaction_ShouldCalculateStandardTransactionFee(
            string merchantName, decimal amount, decimal expected)
        {
            // Arrange
            var transaction = new Transaction { MerchantName = merchantName, Amount = amount };
            var sut = new TransactionPercentageFeeService();

            // Act
            sut.CalculateMerchantFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }

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
            var sut = new CircleKTransactionFeeMerchantPercentageDiscountDecorator(transactionFeeService);

            // Act
            sut.CalculateMerchantFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }
    }
}
