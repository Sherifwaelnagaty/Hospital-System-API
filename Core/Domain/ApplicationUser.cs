using Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Image { get; set; }

        [Required(ErrorMessage = "FullName is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
