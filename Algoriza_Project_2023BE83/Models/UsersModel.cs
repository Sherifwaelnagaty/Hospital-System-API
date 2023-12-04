using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace Algoriza_Project_2023BE83.Models;
public class Usersmodel: BaseModel {

    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    
}