using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Core.Domain;
namespace Core.Models;

public class Doctors
{
    public int Id { get; set; }

    [AllowNull]
    [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than or equal to 0")]
    public decimal Price { get; set; }

    [ForeignKey("FK_Doctors_AspNetUsers_DoctorUserId")]
    public string DoctorUserId { get; set; }

    [ForeignKey("FK_Doctors_Specializations_SpecializationId")]
    public int SpecializationId { get; set; }
    public ApplicationUser DoctorUser { get; set; }
    public Specialization Specialization { get; set; }

}