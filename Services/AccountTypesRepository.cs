using System.Data.SqlClient;
using Dapper;
using BudgetManagement.Models;

namespace BudgetManagement.Services
{
    public interface IAccountTypesRepository 
    {
        void Create(AccountType accountType);
    }

    public class AccountTypesRepository : IAccountTypesRepository
    {
        private readonly string connectionString;
        
        public AccountTypesRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Create(AccountType accountType)
        {
            using var connection = new SqlConnection(connectionString);
            var id = connection.QuerySingle<int>(@"
                INSERT INTO account_type (name, user_id, order_registry)
                VALUES (@Name, @UserId, 0);
                SELECT SCOPE_IDENTITY();", accountType);

            accountType.Id = id;
        }
    }
}
