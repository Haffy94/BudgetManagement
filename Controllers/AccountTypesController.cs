using BudgetManagement.Models;
using Microsoft.AspNetCore.Mvc;
using BudgetManagement.Services;

namespace BudgetManagement.Controllers
{
    public class AccountTypesController : Controller
    {
        private readonly IAccountTypesRepository accountTypesRepository;

        public AccountTypesController(IAccountTypesRepository accountTypesRepository)
        {
            this.accountTypesRepository = accountTypesRepository;
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AccountType accountType)
        {
            if (!ModelState.IsValid)
            {
                return View(accountType);
            }

            accountType.UserId = 1;
            accountTypesRepository.Create(accountType);

            return View();
        }
    }
}
