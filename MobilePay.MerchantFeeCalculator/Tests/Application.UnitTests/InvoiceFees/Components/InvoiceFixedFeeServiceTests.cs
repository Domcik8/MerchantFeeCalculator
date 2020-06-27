using Application.InvoiceFees.Components;
using Domain;
using FluentAssertions;
using Xunit;

namespace Application.UnitTests.InvoiceFees.Components
{
    public class FreeFeeInvoiceFixedFeeDecoratorTests
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
            sut.CalculateInvoiceFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }
    }
}
