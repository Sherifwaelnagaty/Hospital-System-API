using System.ComponentModel.DataAnnotations;

namespace Algoriza_Project_2023BE83.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
