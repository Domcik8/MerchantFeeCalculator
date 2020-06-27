using Application.TransactionFees.Components;
using Domain;
using FluentAssertions;
using Xunit;

namespace Application.UnitTests.TransactionFees
{
    public class TeliaTransactionFeeMerchantPercentageDiscountDecoratorTests
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
    }
}
