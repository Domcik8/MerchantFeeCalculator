using Application.InvoiceFees;
using Application.TransactionFees;
using Infrastructure;
using System;

namespace Application
{
    public class MerchantFeeCalculatorService
    {
        ITransactionRepository TransactionRepository { get; }
        BaseTransactionFeeService TransactionFeeService { get; }
        BaseInvoiceFeeService InvoiceFeeService { get; }

        public MerchantFeeCalculatorService(
            ITransactionRepository transactionRepository,
            BaseTransactionFeeService transactionFeeService, BaseInvoiceFeeService invoiceFeeService)
        {
            TransactionRepository = transactionRepository;
            TransactionFeeService = transactionFeeService;
            InvoiceFeeService = invoiceFeeService;
        }

        public void CalculateFees()
        {
            while (TransactionRepository.HasUnhandledTransactions())
            {
                var transaction = TransactionRepository.GetTransaction();
                if (transaction == null)
                    continue;

                TransactionFeeService.CalculateTransactionFee(transaction);
                InvoiceFeeService.CalculateInvoiceFee(transaction);

                Console.WriteLine($"{transaction.Date}, {transaction.MerchantName}, " +
                    $"{transaction.Amount}, {transaction.Fee}");
            }
        }
    }
}
