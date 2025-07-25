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
        public async Task<IActionResult> Create(AccountType accountType)
        {
            if (!ModelState.IsValid)
            {
                return View(accountType);
            }

            accountType.UserId = 1;

            var accTypeExists =
                    await accountTypesRepository.Exists(accountType.Name, accountType.UserId);

            if (accTypeExists)
            {
                ModelState.AddModelError(nameof(accountType.Name),
                $"El nombre {accountType.Name} ya existe.");

                return View(accountType);
            }

            await accountTypesRepository.Create(accountType);

            return View();
        }
    }
}
