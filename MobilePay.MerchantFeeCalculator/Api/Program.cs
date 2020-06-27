using System.Diagnostics.CodeAnalysis;

namespace Api
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main()
        {
            var merchantFeeCalculator = new MerchantFeeCalculator();
            merchantFeeCalculator.CalculateFees();
        }
    }
}
