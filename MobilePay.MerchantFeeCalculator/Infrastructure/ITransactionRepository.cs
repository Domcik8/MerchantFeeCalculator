using Domain;

namespace Infrastructure
{
    public interface ITransactionRepository
    {
        public Transaction GetTransaction();
    }
}
