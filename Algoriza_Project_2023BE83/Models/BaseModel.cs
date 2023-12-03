using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Algoriza_Project_2023BE83.Models
{
    public class BaseModel : IdentityDbContext
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string? FirstName { get; set; }
        [Required, MaxLength(50)]
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? gender { get; set; }
        public string? Image { get; set; }
        public DateOnly Dateofbirth { get; set; }
    }
}
