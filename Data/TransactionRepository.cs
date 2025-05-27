using AtmApp.Domain;
using Dapper;
using Microsoft.Data.Sqlite;
namespace AtmApp.Data
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly string _connectionString;

        public TransactionRepository(string connectionString)
        {
            _connectionString = connectionString;
            using var db = new SqliteConnection(_connectionString);
            db.Execute(@"CREATE TABLE IF NOT EXISTS Transactions (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Timestamp TEXT NOT NULL,
                Type TEXT NOT NULL,
                Amount REAL NOT NULL,
                Source INTEGER NOT NULL,
                Target INTEGER,
                Description TEXT
            );");
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            using var db = new SqliteConnection(_connectionString);
            var sql = @"INSERT INTO Transactions (Type, Amount, Timestamp, Description, Source, Target)
                        VALUES (@Type, @Amount, @Timestamp, @Description, @Source, @Target);";
            await db.ExecuteAsync(sql, new
            {
                Type = transaction.Type.ToString(),
                transaction.Amount,
                transaction.Timestamp,
                transaction.Description,
                transaction.Source,
                transaction.Target
            });
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            using var db = new SqliteConnection(_connectionString);
            var sql = @"SELECT Id, Type, Amount, Timestamp, Description, Source, Target
                FROM Transactions
                ORDER BY Id DESC
                LIMIT 10";
            IEnumerable<Transaction> results = await db.QueryAsync<Transaction>(sql);
            return results;
        }
    }
}
