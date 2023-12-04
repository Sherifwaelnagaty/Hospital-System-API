using Microsoft.AspNetCore.Identity;
namespace Core.Domain;

public class Doctors : Base
{
    public string Specialize { get; set; }
}