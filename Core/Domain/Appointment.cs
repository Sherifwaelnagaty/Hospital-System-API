using Core.Enums;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Core.Models;
public class Appointment
{
    public string Id { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public Days Days { get; set; }
    public decimal Price { get; set; }
    public string DoctorId { get; set; }
    public string PatientId { get; set; }
    public Doctors Doctor { get; set; }
    public Patients Patient { get; set; } 
}