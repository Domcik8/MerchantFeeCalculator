using Application.TransactionFees;
using Domain;
using FluentAssertions;
using System;
using Xunit;

namespace Application.UnitTests
{
    public class InvoiceFixedFeeServiceTests
    {
        [Theory]
        [InlineData(120)]
        [InlineData(10)]
        [InlineData(300)]
        public void CalculateMerchantFee_ForNonFreeTransaction_ShouldIncludeInvoiceFee(decimal fee)
        {
            // Arrange
            var transaction = new Transaction { Fee = fee };
            var sut = new InvoiceFixedFeeService();
            var expected = fee + InvoiceFixedFeeService.StandardInvoiceFixedFee;

            // Act
            sut.CalculateMerchantFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(0)]
        public void CalculateMerchantFee_ForFreeTransaction_ShouldNotIncludeInvoiceFee(decimal fee)
        {
            // Arrange
            var transaction = new Transaction { Fee = fee };
            var sut = new InvoiceFixedFeeService();
            var expected = 0;

            // Act
            sut.CalculateMerchantFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }
    }
}
