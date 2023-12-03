using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Core.Domain;

public class Doctors : Base
{
    public string Specialize { get; set; }
}