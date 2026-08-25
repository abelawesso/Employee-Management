using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_API.Persistence.Entities
{
    [Table("Employes"), Index(nameof(Matricule), IsUnique = true)]
    public class Employe : AuditableEntity
    {
        [Required(ErrorMessage = "Matricule is required")]
        public string Matricule { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }    
        public string? LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }
        public string? Position { get; set; }
    }
}
