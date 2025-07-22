using BudgetManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManagement.Controllers
{
    public class AccountTypesController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Accounttype accounttype)
        {
            if (!ModelState.IsValid)
            {
                return View(accounttype);
            }

            return View();
        }
    }
}
