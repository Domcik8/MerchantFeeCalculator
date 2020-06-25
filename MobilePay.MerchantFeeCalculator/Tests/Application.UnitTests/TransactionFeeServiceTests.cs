using AutoFixture;
using Domain;
using FluentAssertions;
using System;
using Xunit;

namespace Application.UnitTests
{
    public class TransactionFeeServiceTests
    {
        [Theory]
        [InlineData("2018-09-02", "CIRCLE_K", 120, 1.20)]
        [InlineData("2018-09-04", "Telia", 200, 2.00)]
        [InlineData("2018-10-22", "CIRCLE_K", 300, 3.00)]
        [InlineData("2018-10-29", "CIRCLE_K", 150, 1.50)]
        public void CalculateStandardTransactionFee_AnyTransaction_ShouldCalculateFeeWithoutDiscounts(
            DateTime date, string merchantName, decimal amount, decimal expectedFee)
        {
            // Arrange
            var transaction = new Transaction(date, merchantName, amount);
            var sut = new Fixture().Create<TransactionPercentageFeeService>();

            // Act
            var actual = sut.CalculateStandardTransactionFee(transaction);

            // Assert
            actual.Should().Be(expectedFee);
        }

        [Theory]
        [InlineData("2018-09-02", "TELIA", 120, 1.08)]
        [InlineData("2018-09-04", "TELIA", 200, 1.80)]
        [InlineData("2018-10-22", "TELIA", 300, 2.70)]
        [InlineData("2018-10-29", "TELIA", 150, 1.35)]
        public void CalculateTransactionFee_WithTeliaTransaction_ShouldCalculateFeeWithTeliaDiscount(
            DateTime date, string merchantName, decimal amount, decimal expectedFee)
        {
            // Arrange
            var transaction = new Transaction(date, merchantName, amount);
            var sut = new Fixture().Create<TransactionPercentageFeeService>();

            // Act
            var actual = sut.CalculateTransactionFee(transaction);

            // Assert
            actual.Should().Be(expectedFee);
        }
    }
}
