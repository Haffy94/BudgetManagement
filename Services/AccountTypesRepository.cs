using System.Data.SqlClient;
using Dapper;
using BudgetManagement.Models;

namespace BudgetManagement.Services
{
    public interface IAccountTypesRepository
    {
        Task Create(AccountType accountType);
        Task<bool> Exists(string name, int userId);
    }

    public class AccountTypesRepository : IAccountTypesRepository
    {
        private readonly string connectionString;

        public AccountTypesRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Create(AccountType accountType)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>
                (@"INSERT INTO account_type (name, user_id, order_registry)
                VALUES (@Name, @UserId, 0);
                SELECT SCOPE_IDENTITY();", accountType);

            accountType.Id = id;
        }

        public async Task<bool> Exists(string name, int userId)
        {
            using var connection = new SqlConnection(connectionString);
            var exists = await connection.QueryFirstOrDefaultAsync<int>
            (
                @"SELECT 1 
                FROM account_type
                WHERE name = @Name AND user_id = @UserId",
                new { name, userId }
            );

            return exists == 1;
        }
    }
}
