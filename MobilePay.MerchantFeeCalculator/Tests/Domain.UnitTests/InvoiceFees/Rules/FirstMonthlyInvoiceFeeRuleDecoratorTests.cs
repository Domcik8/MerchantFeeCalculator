using Domain.InvoiceFees.Rules;
using Domain.Models;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.UnitTests.InvoiceFees.Rules
{
    public class FirstMonthlyInvoiceFeeRuleDecoratorTests
    {
        [Fact]
        public void CalculateMerchantFee_ForMoreThenOneMonthlyTransactions_ShouldNotIncludeInvoiceFee()
        {
            // Arrange
            var transaction1 =
                new Transaction { Date = new DateTime(2018, 09, 02), MerchantName = "7-Eleven", Fee = 1 };
            var transaction2 =
                new Transaction { Date = new DateTime(2018, 09, 05), MerchantName = "Netto", Fee = 1 };
            var transaction3 =
                new Transaction { Date = new DateTime(2018, 10, 22), MerchantName = "7-Eleven", Fee = 1 };
            var transaction4 =
                new Transaction { Date = new DateTime(2018, 10, 29), MerchantName = "7-Eleven", Fee = 1 };

            var expected1 = transaction1.Fee + TestInvoiceFeeService.StandardInvoiceFixedFee;
            var expected2 = transaction2.Fee + TestInvoiceFeeService.StandardInvoiceFixedFee;
            var expected3 = transaction3.Fee + TestInvoiceFeeService.StandardInvoiceFixedFee;
            var expected4 = transaction4.Fee;

            var invoiceFeeService = new TestInvoiceFeeService();
            var sut = new FirstMonthlyInvoiceFeeRuleDecorator(invoiceFeeService);

            // Act
            sut.CalculateInvoiceFee(transaction1);
            var actual1 = transaction1.Fee;

            sut.CalculateInvoiceFee(transaction2);
            var actual2 = transaction2.Fee;

            sut.CalculateInvoiceFee(transaction3);
            var actual3 = transaction3.Fee;

            sut.CalculateInvoiceFee(transaction4);
            var actual4 = transaction4.Fee;

            // Assert
            actual1.Should().Be(expected1);
            actual2.Should().Be(expected2);
            actual3.Should().Be(expected3);
            actual4.Should().Be(expected4);
        }
    }
}
