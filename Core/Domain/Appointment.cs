using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Core.Models;
public class Appointment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    public DateTime Time { get; set; }
    public Days Days { get; set; }
    public decimal Price { get; set; }
    public string DoctorId { get; set; }
    public string PatientId { get; set; }
    public virtual Doctors Doctor { get; set; }
    public virtual Patients Patient { get; set; } 
}