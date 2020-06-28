using Application;
using Domain.InvoiceFees.Base;
using Domain.InvoiceFees.Rules;
using Domain.InvoiceFees.Types;
using Domain.TransactionFees.Base;
using Domain.TransactionFees.MerchantPercentageDiscounts;
using Domain.TransactionFees.Types;
using FluentAssertions;
using Infrastructure.Repositories;
using System;
using System.IO;
using Xunit;

namespace Application.IntegrationTests
{
    public class MerchantFeeCalculatorServiceTests
    {
        [Fact]
        public void CalculateFeesTest_WithTransactionsFile_ShouldWriteExpectedConsoleOutput()
        {
            // Arrange
            using StreamReader expectedOutput = new StreamReader("Expected.Result.txt");
            var expected = expectedOutput.ReadToEnd();

            using StringWriter actualOutput = new StringWriter();
            Console.SetOut(actualOutput);

            var transactionRepository = new TxtTransactionRepository();

            BaseTransactionFeeService transactionFeeService = new TransactionPercentageFeeService();
            transactionFeeService = new TeliaPercentageDiscountDecorator(transactionFeeService);
            transactionFeeService = new CircleKPercentageDiscountDecorator(transactionFeeService);

            BaseInvoiceFeeService invoiceFeeService = new InvoiceFixedFeeService();
            invoiceFeeService = new FirstMonthlyInvoiceFeeRuleDecorator(invoiceFeeService);
            invoiceFeeService = new FreeInvoiceFeeRuleDecorator(invoiceFeeService);

            var sut =
                new MerchantFeeCalculatorService(transactionRepository, transactionFeeService, invoiceFeeService);

            // Act
            sut.CalculateFees();
            var actual = actualOutput.ToString();

            // Assert
            expected.Should().Be(actual);
        }
    }
}
