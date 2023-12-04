using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    public class Base : IdentityUser
    {

        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string gender { get; set; }
        public string Image { get; set; }
        public DateOnly Dateofbirth { get; set; }
    }
}
