namespace AtmApp.Domain
{
    public class Account
    {
        public AccountType Type { get; set; }

        public decimal Balance { get; private set; }

        public List<Transaction> Transactions { get; set; } = new();

        public Account(AccountType type)
        {
            Type = type;
        }    
        public void SetBalanceForPersistence(decimal amount)
        {
            Balance = amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");

            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds.");

            Balance -= amount;
        }

        public void TransferTo(Account target, decimal amount)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            if (target.Type == this.Type)
                throw new InvalidOperationException("Cannot transfer to the same account.");

            this.Withdraw(amount);
            target.Deposit(amount);
        }
    }
}
