using Domain;

namespace Application.TransactionFees
{
    public class InvoiceFixedFeeService : BaseMerchantFeeService
    {
        public const decimal StandardInvoiceFixedFee = 29;

        public override void CalculateMerchantFee(Transaction transaction)
        {
            CalculateInvoiceFixedFee(transaction);
        }

        private void CalculateInvoiceFixedFee(Transaction transaction)
        {
            if (IsFreeTransaction(transaction))
                return;

            transaction.Fee += StandardInvoiceFixedFee;
        }

        private bool IsFreeTransaction(Transaction transaction)
        {
            return transaction.Fee <= 0;
        }
    }
}
