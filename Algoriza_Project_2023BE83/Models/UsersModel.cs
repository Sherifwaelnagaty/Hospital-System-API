using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Algoriza_Project_2023BE83.Models
{
    public class UsersModel : IdentityUser
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }
    }
}