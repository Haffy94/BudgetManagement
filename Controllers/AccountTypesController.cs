using BudgetManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;

namespace BudgetManagement.Controllers
{
    public class AccountTypesController : Controller
    {
        private readonly string connectionString;

        public AccountTypesController(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        
        public IActionResult Create()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = connection.Query("SELECT 1").FirstOrDefault();
            }
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(AccountType accountType)
        {
            if (!ModelState.IsValid)
            {
                return View(accountType);
            }

            return View();
        }
    }
}
