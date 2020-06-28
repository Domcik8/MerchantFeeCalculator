using Domain.TransactionFees.Base;
using Domain.TransactionFees.MerchantPercentageDiscounts.Base;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTests.TransactionFees.MerchantPercentageDiscounts.Base
{
    public class BaseMerchantPercentageDiscountDecoratorTests
    {
        [Theory]
        [InlineData("MERCHANT_WITH_DISCOUNT", 1.20, 0.60)]
        [InlineData("MERCHANT_WITH_DISCOUNT", 2.00, 1.00)]
        [InlineData("MERCHANT_WITH_DISCOUNT", 3.00, 1.50)]
        [InlineData("MERCHANT_WITH_DISCOUNT", 1.50, 0.75)]
        public void CalculateMerchantFee_ForMerchantWithDiscountTransaction_ShouldApplyDiscount(
            string merchantName, decimal fee, decimal expected)
        {
            // Arrange
            var transaction = new Transaction { MerchantName = merchantName, Fee = fee };
            var transactionFeeService = new TestTransactionFeeService();
            var sut = new ConcretePercentageDiscountDecorator(transactionFeeService);

            // Act
            sut.CalculateTransactionFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("CIRCLE_K", 1.20, 1.20)]
        [InlineData("7-ELEVEN", 2.00, 2.00)]
        [InlineData("NETTO", 3.00, 3.00)]
        [InlineData("MERCHANT_WITHOUT_DISCOUNT", 1.50, 1.50)]
        public void CalculateMerchantFee_ForMerchantWithoutDiscountTransaction_ShouldNotApplyDiscount(
            string merchantName, decimal fee, decimal expected)
        {
            // Arrange
            var transaction = new Transaction { MerchantName = merchantName, Fee = fee };
            var transactionFeeService = new TestTransactionFeeService();
            var sut = new ConcretePercentageDiscountDecorator(transactionFeeService);

            // Act
            sut.CalculateTransactionFee(transaction);
            var actual = transaction.Fee;

            // Assert
            actual.Should().Be(expected);
        }
        public class ConcretePercentageDiscountDecorator : BaseMerchantPercentageDiscountDecorator
        {
            private const string ConcreteMerchantName = "MERCHANT_WITH_DISCOUNT";
            private const decimal ConcreteMerchantFeeDiscountPercentage = 0.5m;

            public ConcretePercentageDiscountDecorator(BaseTransactionFeeService transactionFeeService)
                : base(transactionFeeService, ConcreteMerchantName, ConcreteMerchantFeeDiscountPercentage) { }
        }
    }
}
