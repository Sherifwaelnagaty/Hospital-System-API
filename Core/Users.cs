using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace Core.Domain;

public class Users : Base
{

    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

}