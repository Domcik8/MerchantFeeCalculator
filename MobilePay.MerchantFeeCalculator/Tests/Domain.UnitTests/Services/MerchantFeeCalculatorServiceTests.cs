using Domain.InvoiceFees.Base;
using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using Domain.TransactionFees.Base;
using Domain.UnitTests.InvoiceFees.Rules;
using Domain.UnitTests.TransactionFees.MerchantPercentageDiscounts;
using FluentAssertions;
using Moq;
using System;
using System.IO;
using Xunit;

namespace Domain.UnitTests.Services
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

            var transactionRepository = GetMockedTransactionRepository();

            BaseTransactionFeeService transactionFeeService = new TestTransactionFeeService();
            BaseInvoiceFeeService invoiceFeeService = new TestInvoiceFeeService();

            var sut =
                new MerchantFeeCalculatorService(transactionRepository, transactionFeeService, invoiceFeeService);

            // Act
            sut.CalculateFees();
            var actual = actualOutput.ToString();

            // Assert
            expected.Should().Be(actual);
        }

        private ITransactionRepository GetMockedTransactionRepository()
        {
            var transaction1 =
                new Transaction { Date = new DateTime(2018, 09, 02), MerchantName = "7-ELEVEN", Fee = 1 };
            var transaction2 =
                new Transaction { Date = new DateTime(2018, 09, 05), MerchantName = "NETTO", Fee = 1 };

            var transactionRepositoryMock = new Mock<ITransactionRepository>();

            transactionRepositoryMock.SetupSequence(x => x.HasUnhandledTransactions())
                .Returns(true)
                .Returns(true)
                .Returns(false);

            transactionRepositoryMock.SetupSequence(x => x.GetTransaction())
                .Returns(transaction1)
                .Returns(transaction2);

            return transactionRepositoryMock.Object;
        }
    }
}
