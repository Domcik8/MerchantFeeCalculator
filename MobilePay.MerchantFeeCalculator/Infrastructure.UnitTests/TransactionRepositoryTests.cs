using FluentAssertions;
using System.IO;
using Xunit;

namespace Infrastructure.UnitTests
{
    public class TransactionRepositoryTests
    {
        [Fact]
        public void TransactionRepository_TransactionFileDoesNotExist_ThrowFileNotFoundException()
        {
            // Arrange
            var sut = new TransactionRepository("InvalidPath");

            // Act && Assert
            sut.Invoking(sut => sut.GetTransaction())
                .Should().Throw<FileNotFoundException>();
        }
    }
}
