using AtmApp.Domain;

namespace AtmApp.Services
{
    public interface IAccountService
    {
        Task<Account> GetAccountAsync(AccountType type);
        Task DepositAsync(AccountType type, decimal amount);
        Task WithdrawAsync(AccountType type, decimal amount);
        Task TransferAsync(AccountType from, AccountType to, decimal amount);
    }
}
