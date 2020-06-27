using Domain;
using System;
using System.IO;
using System.Linq;

namespace Infrastructure
{
    public class TransactionRepository : ITransactionRepository
    {
        private string _transactionFilePath;
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


        public TransactionRepository() : this("transactions.txt") { }

        public TransactionRepository(string transactionFilePath)
        {
            _transactionFilePath = transactionFilePath;
        }

        public bool HasUnhandledTransactions()
        {
            return !TransactionFile.EndOfStream;
        }

        public string GetTransaction()
        {
            var line = TransactionFile.ReadLine();

            if (line.Trim() == String.Empty)
                return null;

            return line;
        }
    }
}
