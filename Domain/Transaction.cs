namespace AtmApp.Domain
{
    public class Transaction
    {
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public TransactionType Type { get; set; }

        public decimal Amount { get; set; }

        public AccountType Source { get; set; }

        public AccountType? Target { get; set; } // null unless it's a transfer

        public string Description { get; set; } = string.Empty;
    }
}
