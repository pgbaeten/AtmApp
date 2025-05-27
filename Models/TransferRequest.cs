using AtmApp.Domain;

namespace AtmApp.Models
{
    public class TransferRequest
    {
        public AccountType From { get; set; }

        public AccountType To { get; set; }

        public decimal Amount { get; set; }
    }
}