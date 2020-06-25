using Application.TransactionFees;
using Domain;
using FluentAssertions;
using Xunit;

namespace Application.UnitTests.InvoiceFees.Rules
{
    public class FreeFeeInvoiceFixedFeeDecoratorTests
    {
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
