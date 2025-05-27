using AtmApp.Domain;

namespace AtmApp.Data
{
    public interface ITransactionRepository
    {
        Task AddTransactionAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetTransactionsAsync();
    }
}

