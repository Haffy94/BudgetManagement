using System.ComponentModel.DataAnnotations;

namespace BudgetManagement.Models
{
    public class Accounttype
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(maximumLength : 50, MinimumLength = 3, ErrorMessage = "El campo nombre debe tener un mínimo de {2} caracteres y un máximo de {1}")]
        public string Name { get; set; }
        public int UserId { get; set; }
        public int Order { get; set; }
    }

}

