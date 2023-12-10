using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Base : IdentityUser
    {

        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string gender { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public DateOnly Dateofbirth { get; set; }
    }
}
