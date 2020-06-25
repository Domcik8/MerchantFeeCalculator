using Application.TransactionFees;
using Application.TransactionFees.MerchantPercentageDiscounts;
using Domain;
using FluentAssertions;
using System;
using Xunit;

namespace Application.UnitTests
{
    public class TransactionPercentageFeeServiceTests
    {
        [Theory]
        [InlineData("2018-09-02", "CIRCLE_K", 120, 1.20)]
        [InlineData("2018-09-04", "Telia", 200, 2.00)]
        [InlineData("2018-10-22", "CIRCLE_K", 300, 3.00)]
        [InlineData("2018-10-29", "CIRCLE_K", 150, 1.50)]
        public void CalculateMerchantFee_ForAnyTransaction_ShouldCalculateStandardTransactionFee(
            DateTime date, string merchantName, decimal amount, decimal expected)
        {
            // Arrange
            var transaction = new Transaction(date, merchantName, amount);
            var sut = new TransactionPercentageFeeService();

            // Act
            sut.CalculateMerchantFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("2018-09-02", "TELIA", 120, 1.08)]
        [InlineData("2018-09-04", "TELIA", 200, 1.80)]
        [InlineData("2018-10-22", "TELIA", 300, 2.70)]
        [InlineData("2018-10-29", "TELIA", 150, 1.35)]
        public void CalculateMerchantFee_ForTeliaTransaction_ShouldApplyDiscount(
            DateTime date, string merchantName, decimal amount, decimal expected)
        {
            // Arrange
            var transaction = new Transaction(date, merchantName, amount);
            var transactionFeeService = new TransactionPercentageFeeService();
            var sut = new TeliaTransactionFeeMerchantPercentageDiscountDecorator(transactionFeeService);

            // Act
            sut.CalculateMerchantFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("2018-09-02", "CIRCLE_K", 120, 0.96)]
        [InlineData("2018-09-04", "CIRCLE_K", 200, 1.60)]
        [InlineData("2018-10-22", "CIRCLE_K", 300, 2.40)]
        [InlineData("2018-10-29", "CIRCLE_K", 150, 1.20)]
        public void CalculateMerchantFee_ForCircleKTransaction_ShouldApplyDiscount(
            DateTime date, string merchantName, decimal amount, decimal expected)
        {
            // Arrange
            var transaction = new Transaction(date, merchantName, amount);
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
