using System;
using System.IO;
using Xunit;

namespace Api.IntegrationTest
{
    public class MerchantFeeCalculatorTests
    {
        [Fact]
        public void CalculateFeesTest_WithTransactionsFile_ShouldWriteExpectedConsoleOutput()
        {
            // Arrange
            using StreamReader expectedOutput = new StreamReader("Expected.Result.txt");
            var expected = expectedOutput.ReadToEnd();

            using StringWriter actualOutput = new StringWriter();
            Console.SetOut(actualOutput);
            
            var sut = new MerchantFeeCalculator();

            // Act
            sut.CalculateFees();
            var actual = actualOutput.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
