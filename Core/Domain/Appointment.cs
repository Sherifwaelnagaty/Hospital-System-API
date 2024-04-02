using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Core.Models;
public class Appointment
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Day is required.")]
    [EnumDataType(typeof(Days))]
    public Days DayOfWeek { get; set; }
    [ForeignKey("FK_Appointments_Doctors_DoctorId")]
    [AllowNull]
    public virtual int DoctorId {get; set;}
}