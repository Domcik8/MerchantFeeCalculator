using Infrastructure;
using System;

namespace Application
{
    public class MerchantFeeCalculatorService
    {
        ITransactionRepository TransactionRepository { get; }
        BaseMerchantFeeService MerchantFeeService { get; }

        public MerchantFeeCalculatorService(
            ITransactionRepository transactionRepository, BaseMerchantFeeService merchantFeeService)
        {
            TransactionRepository = transactionRepository;
            MerchantFeeService = merchantFeeService;
        }

        public void CalculateFees()
        {
            while (TransactionRepository.HasUnhandledTransactions())
            {
                var transaction = TransactionRepository.GetTransaction();
                if (transaction == null)
                    continue;

                MerchantFeeService.CalculateMerchantFee(transaction);

                Console.WriteLine($"{transaction.Date}, {transaction.MerchantName}, " +
                    $"{transaction.Amount}, {transaction.Fee}");
            }
        }
    }
}
