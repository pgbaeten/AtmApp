using AtmApp.Domain;

namespace AtmApp.Data
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountAsync(AccountType type);
        Task SaveAccountAsync(Account account);
    }
}