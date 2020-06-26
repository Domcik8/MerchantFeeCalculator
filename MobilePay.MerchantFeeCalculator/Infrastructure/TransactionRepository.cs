using Domain;
using System;
using System.IO;

namespace Infrastructure
{
    public class TransactionRepository : ITransactionRepository
    {
        public string TransactionFilePath { get; }

        public TransactionRepository() : this("transactions.txt") { }

        public TransactionRepository(string transactionFilePath)
        {
            TransactionFilePath = transactionFilePath;
        }

        public Transaction GetTransaction()
        {
            var file = new StreamReader(TransactionFilePath);

            // Read line.
            // Yield transaction.

            while (!file.EndOfStream)
            {
                var line = file.ReadLine();

                Console.WriteLine(line);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            return null;
        }
    }
}
