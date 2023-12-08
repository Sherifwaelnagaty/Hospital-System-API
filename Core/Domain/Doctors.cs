using Microsoft.AspNetCore.Identity;
namespace Core.Models;

public class Doctors : Base
{
    public string Specialize { get; set; }
    public ICollection<Appointment> Appointments { get; set; }

}