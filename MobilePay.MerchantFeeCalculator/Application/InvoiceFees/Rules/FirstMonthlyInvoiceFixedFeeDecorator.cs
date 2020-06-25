using Application.TransactionFees.MerchantPercentageDiscounts;
using Domain;
using System;
using System.Collections.Generic;

namespace Application.InvoiceFees.Rules
{
    /// <summary>
    /// Add invoice fixed fee only to first transaction in the month.
    /// </summary>
    public class FirstMonthlyInvoiceFixedFeeDecorator : BaseMerchantFeeDecorator
    {
        /// <summary>
        /// Month for which the fee is being calculated.
        /// </summary>
        private DateTime FeeMonth = DateTime.MinValue;

        private List<string> IssuedMonthlyFees = new List<string>();

        public FirstMonthlyInvoiceFixedFeeDecorator(BaseMerchantFeeService transactionFeeService)
            : base(transactionFeeService) { }

        public override void CalculateMerchantFee(Transaction transaction)
        {
            if (IsNewFeeMonth(transaction))
                UpdateFeeMonth(transaction);

            if (HasFeeBeenPaid(transaction))
                return;

            IssuedMonthlyFees.Add(transaction.MerchantName);

            base.CalculateMerchantFee(transaction);
        }

        private bool IsNewFeeMonth(Transaction transaction)
        {
            return !(transaction.Date.Month == FeeMonth.Month && transaction.Date.Year == FeeMonth.Year);
        }

        private void UpdateFeeMonth(Transaction transaction)
        {
            IssuedMonthlyFees.Clear();
            FeeMonth = transaction.Date;
        }

        private bool HasFeeBeenPaid(Transaction transaction)
        {
            return IssuedMonthlyFees.Contains(transaction.MerchantName);
        }
    }
}