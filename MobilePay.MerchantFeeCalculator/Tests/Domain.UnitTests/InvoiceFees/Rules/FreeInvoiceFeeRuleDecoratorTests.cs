using Domain.InvoiceFees.Rules;
using Domain.Models;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTests.InvoiceFees.Rules
{
    public class FreeInvoiceFeeRuleDecoratorTests
    {
        [Theory]
        [InlineData(0)]
        public void CalculateMerchantFee_ForFreeTransaction_ShouldNotIncludeInvoiceFee(decimal fee)
        {
            // Arrange
            var transaction = new Transaction { Fee = fee };
            var invoiceFeeService = new TestInvoiceFeeService();
            var sut = new FreeInvoiceFeeRuleDecorator(invoiceFeeService);
            var expected = 0;

            // Act
            sut.CalculateInvoiceFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }
    }
}
