using System.ComponentModel.DataAnnotations;
using BudgetManagement.Validations;

namespace BudgetManagement.Models
{
    public class AccountType
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "El campo nombre debe tener un mínimo de {2} caracteres y un máximo de {1}")]
        [CapitalizedFirstLetter]
        public string Name { get; set; }
        public int UserId { get; set; }
        public int Order { get; set; }
    }
}

