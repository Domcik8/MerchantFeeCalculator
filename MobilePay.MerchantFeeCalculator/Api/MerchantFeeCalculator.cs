﻿using Domain.InvoiceFees.Base;
using Domain.InvoiceFees.Rules;
using Domain.InvoiceFees.Types;
using Domain.Services;
using Domain.TransactionFees.Base;
using Domain.TransactionFees.MerchantPercentageDiscounts;
using Domain.TransactionFees.Types;
using Infrastructure.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace Api
{
    [ExcludeFromCodeCoverage]
    public class MerchantFeeCalculator
    {
        public void CalculateFees()
        {
            var transactionRepository = new TxtTransactionRepository();

            BaseTransactionFeeService transactionFeeService = new TransactionPercentageFeeService();
            transactionFeeService = new TeliaPercentageDiscountDecorator(transactionFeeService);
            transactionFeeService = new CircleKPercentageDiscountDecorator(transactionFeeService);

            BaseInvoiceFeeService invoiceFeeService = new InvoiceFixedFeeService();
            invoiceFeeService = new FirstMonthlyInvoiceFeeRuleDecorator(invoiceFeeService);
            invoiceFeeService = new FreeInvoiceFeeRuleDecorator(invoiceFeeService);
            
            var merchantFeeCalculator =
                new MerchantFeeCalculatorService(transactionRepository, transactionFeeService, invoiceFeeService);

            merchantFeeCalculator.CalculateFees();
        }
    }
}
