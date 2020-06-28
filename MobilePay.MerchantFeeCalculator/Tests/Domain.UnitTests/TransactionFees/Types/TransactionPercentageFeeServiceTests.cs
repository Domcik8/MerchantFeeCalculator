using Domain.TransactionFees.Types;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTests.TransactionFees.Types
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
            sut.CalculateTransactionFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }
    }
}
