using Application.InvoiceFees.Components;
using Application.InvoiceFees.Decorators;
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
            var invoiceFeeService = new TestInvoiceFeeService();
            var sut = new FreeFeeInvoiceFixedFeeDecorator(invoiceFeeService);
            var expected = 0;

            // Act
            sut.CalculateInvoiceFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }
    }
}
