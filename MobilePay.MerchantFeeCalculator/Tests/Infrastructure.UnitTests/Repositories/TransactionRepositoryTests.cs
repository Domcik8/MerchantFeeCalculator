using FluentAssertions;
using Infrastructure.Repositories;
using System.IO;
using Xunit;

namespace Infrastructure.UnitTests.Repositories
{
    public class TransactionRepositoryTests
    {
        [Fact]
        public void TransactionRepository_WithNotExistingTransactionFile_ThrowFileNotFoundException()
        {
            // Arrange
            var sut = new TxtTransactionRepository("InvalidPath");

            // Act && Assert
            sut.Invoking(sut => sut.GetTransaction())
                .Should().Throw<FileNotFoundException>();
        }

        [Theory]
        [InlineData(3)]
        public void TransactionRepository_WithCorrectTransactions_FetchesCorrectTransactions(
            int expectedCountOfTransactions)
        {
            // Arrange
            var actualTransactionCount = 0;
            var sut = new TxtTransactionRepository("Correct.Transactions.txt");

            // Act && Assert
            while (sut.HasUnhandledTransactions())
            {
                sut.GetTransaction();
                actualTransactionCount++;
            }

            // Assert
            actualTransactionCount.Should().Be(expectedCountOfTransactions);
        }

        [Theory]
        [InlineData(3)]
        public void TransactionRepository_WithIncorrectTransactions_FetchesCorrectTransactions(
            int expectedCountOfTransactions)
        {
            // Arrange
            var actualTransactionCount = 0;
            var sut = new TxtTransactionRepository("Incorrect.Transactions.txt");

            // Act && Assert
            while (sut.HasUnhandledTransactions())
            {
                var transaction = sut.GetTransaction();
                if (transaction != null)
                    actualTransactionCount++;
            }

            // Assert
            actualTransactionCount.Should().Be(expectedCountOfTransactions);
        }
    }
}
