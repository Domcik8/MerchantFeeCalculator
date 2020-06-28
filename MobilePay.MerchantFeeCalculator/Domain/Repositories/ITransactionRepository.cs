using Domain.Models;

namespace Domain.Repositories
{
    public interface ITransactionRepository
    {
        /// <summary>
        /// Check if there are transactions that have not been handled.
        /// </summary>
        public bool HasUnhandledTransactions();

        /// <summary>
        /// Get next unhandled transaction.
        /// </summary>
        public Transaction GetTransaction();
    }
}
