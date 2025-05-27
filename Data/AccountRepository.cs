using Dapper;
using System.Data;
using AtmApp.Domain;
using Microsoft.Data.Sqlite;

namespace AtmApp.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbConnection _db;

        public AccountRepository(string connectionString)
        {
            _db = new SqliteConnection(connectionString);
            _db.Execute(@"CREATE TABLE IF NOT EXISTS Accounts (
                Type TEXT PRIMARY KEY,
                Balance REAL NOT NULL
            );");
        }

        public async Task<Account> GetAccountAsync(AccountType type)
        {
            var sql = "SELECT Balance FROM Accounts WHERE Type = @Type;";
            var balance = await _db.ExecuteScalarAsync<decimal?>(sql, new { Type = type.ToString() }) ?? 0;

            var account = new Account(type);
            account.SetBalanceForPersistence(balance); // ✅ Controlled setter
            return account;
        }

        public async Task SaveAccountAsync(Account account)
        {
            var sql = @"
                INSERT INTO Accounts (Type, Balance)
                VALUES (@Type, @Balance)
                ON CONFLICT(Type) DO UPDATE SET Balance = @Balance;
            ";
            await _db.ExecuteAsync(sql, new { Type = account.Type.ToString(), account.Balance });
        }
    }
}
