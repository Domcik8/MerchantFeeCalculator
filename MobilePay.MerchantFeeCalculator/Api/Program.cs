namespace Api
{
    public class Program
    {
        public static void Main()
        {
            var merchantFeeCalculator = new MerchantFeeCalculator();
            merchantFeeCalculator.CalculateFees();
        }
    }
}
