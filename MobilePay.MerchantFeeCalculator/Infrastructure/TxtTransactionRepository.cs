using Domain;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Infrastructure
{
    /// <summary>
    /// Transaction repository implemented over txt files.
    /// </summary>
    public class TxtTransactionRepository : ITransactionRepository
    {
        // Corresponds to Date MerchantName Amount
        private readonly string _transactionPattern = @"^(\d{4})-(\d{2})-(\d{2})\s+(\S+)\s+(\S+)$";
        private readonly string _transactionFilePath;
        private StreamReader _transactionFile;

        public StreamReader TransactionFile
        {
            get
            {
                if (_transactionFile == null)
                    _transactionFile = new StreamReader(_transactionFilePath);

                return _transactionFile;
            }
            set { }
        }


        public TxtTransactionRepository() : this("transactions.txt") { }

        public TxtTransactionRepository(string transactionFilePath)
        {
            _transactionFilePath = transactionFilePath;
        }

        public bool HasUnhandledTransactions() => !TransactionFile.EndOfStream;

        /// <summary>
        /// Gets next unhandled transaction from the txt file.
        /// If the transaction does not conform to <see cref="_transactionPattern"/> then null is returned.
        /// </summary>
        public Transaction GetTransaction() => MapStringToTransaction(TransactionFile.ReadLine());

        private Transaction MapStringToTransaction(string transaction)
        {
            transaction = transaction.Trim();
            var match = Regex.Match(transaction, _transactionPattern);

            if (!match.Success)
                return null;

            try
            {
                var year = int.Parse(match.Groups[1].Value);
                var month = int.Parse(match.Groups[2].Value);
                var day = int.Parse(match.Groups[3].Value);

                var merchantName = match.Groups[4].Value;

                var amount = decimal.Parse(match.Groups[5].Value);

                return new Transaction
                {
                    Date = new DateTime(year, month, day),
                    MerchantName = merchantName,
                    Amount = amount
                };
            }
            catch (FormatException)
            {
                return null;
            }
        }
    }
}
