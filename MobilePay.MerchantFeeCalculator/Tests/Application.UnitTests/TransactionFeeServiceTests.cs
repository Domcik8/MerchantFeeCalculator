using AutoFixture;
using Domain;
using FluentAssertions;
using System;
using Xunit;
using Xunit.Sdk;

namespace Application.UnitTests
{
    public class TransactionFeeServiceTests
    {
        [Theory]
        [InlineData("2018-09-02", "CIRCLE_K", "120", "1.20")]
        [InlineData("2018-09-04", "CIRCLE_K", "200", "2.00")]
        [InlineData("2018-10-22", "CIRCLE_K", "300", "3.00")]
        [InlineData("2018-10-29", "CIRCLE_K", "150", "1.50")]
        public void CalculateTransactionFee_WithCorrectInput_ShouldCalculateFee(
            string amount, string merchantName, DateTime date, string expectedFee)
        {
            // Arrange
            var transaction = new Transaction(date, merchantName, amount);
            var sut = new Fixture().Create<ITransactionFeeService>();

            // Act
            sut.CalculateTransactionFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Equals(expectedFee);
        }
    }
}
