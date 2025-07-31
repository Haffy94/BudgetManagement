using System.ComponentModel.DataAnnotations;
using BudgetManagement.Validations;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManagement.Models
{
    public class AccountType
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [CapitalizedFirstLetter]
        [Remote(action: "CheckIfExists", controller:"AccountTypes")]
        public string Name { get; set; }
        public int UserId { get; set; }
        public int Order { get; set; }
    }
}

