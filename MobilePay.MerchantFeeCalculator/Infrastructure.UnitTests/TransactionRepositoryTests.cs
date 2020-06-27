using FluentAssertions;
using System.IO;
using Xunit;

namespace Infrastructure.UnitTests
{
    public class TransactionRepositoryTests
    {
        [Fact]
        public void TransactionRepository_WithNotExistingTransactionFile_ThrowFileNotFoundException()
        {
            // Arrange
            var sut = new TransactionRepository("InvalidPath");

            // Act && Assert
            sut.Invoking(sut => sut.GetTransaction())
                .Should().Throw<FileNotFoundException>();
        }

        [Theory]
        [InlineData(3)]
        public void TransactionRepository_WithFileWithAllCorrectTransactionsWithoutEmptyLines_FetchesAllTransactions(
            int expectedCountOfTransactions)
        {
            // Arrange
            var actualTransactionCount = 0;
            var sut = new TransactionRepository("Correct.Transactions.txt");

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
        public void TransactionRepository_WithFileWithAllCorrectTransactionsWithEmptyLines_FetchesAllTransactions(
            int expectedCountOfTransactions)
        {
            // Arrange
            var actualTransactionCount = 0;
            var sut = new TransactionRepository("Correct.Transactions.WithEmptyLines.txt");

            // Act && Assert
            while (sut.HasUnhandledTransactions())
            {
                var line = sut.GetTransaction();
                if (line != null)
                    actualTransactionCount++;
            }

            // Assert
            actualTransactionCount.Should().Be(expectedCountOfTransactions);
        }
    }
}
