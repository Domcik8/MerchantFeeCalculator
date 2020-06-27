using Domain;

namespace Infrastructure
{
    public interface ITransactionRepository
    {
        public bool HasUnhandledTransactions();
        public string GetTransaction();
    }
}
