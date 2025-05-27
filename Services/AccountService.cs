using AtmApp.Domain;
using AtmApp.Data;

namespace AtmApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly ITransactionRepository _transactionRepository;

        public AccountService(IAccountRepository repository, ITransactionRepository transactionRepository)
        {
            _repository = repository;
            _transactionRepository = transactionRepository;
        }

        public async Task<Account> GetAccountAsync(AccountType type)
        {
            return await _repository.GetAccountAsync(type);
        }

        public async Task DepositAsync(AccountType type, decimal amount)
        {
            var account = await _repository.GetAccountAsync(type);
            account.Deposit(amount);
            await _repository.SaveAccountAsync(account);
            await _transactionRepository.AddTransactionAsync(new Transaction
            {
                Timestamp = DateTime.UtcNow,
                Amount = amount,
                Type = TransactionType.Deposit,
                Description = $"Deposited ${amount} Into Your {type} Account",
                Source = type
            });
        }

        public async Task WithdrawAsync(AccountType type, decimal amount)
        {
            var account = await _repository.GetAccountAsync(type);
            account.Withdraw(amount);
            await _repository.SaveAccountAsync(account);
            await _transactionRepository.AddTransactionAsync(new Transaction
            {
                Timestamp = DateTime.UtcNow,
                Amount = amount,
                Type = TransactionType.Withdraw,
                Description = $"Withdrew ${amount} From Your {type} Account",
                Source = type
            });
        }

        public async Task TransferAsync(AccountType from, AccountType to, decimal amount)
        {
            if (from == to)
                throw new InvalidOperationException("Cannot transfer between the same account.");

            var source = await _repository.GetAccountAsync(from);
            var target = await _repository.GetAccountAsync(to);

            source.TransferTo(target, amount);

            await _repository.SaveAccountAsync(source);
            await _repository.SaveAccountAsync(target);
            await _transactionRepository.AddTransactionAsync(new Transaction
            {
                Timestamp = DateTime.UtcNow,
                Amount = amount,
                Type = TransactionType.Transfer,
                Description = $"Transferred ${amount} From Your {from} Account Into Your {to}",
                Source = from,
                Target = to
            });
        }
    }
}
