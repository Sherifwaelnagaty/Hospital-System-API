﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class AppointmentTime
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Time is required.")]
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }
        [ForeignKey("FK_AppointmentTimes_Appointments_AppointmentId")]
        public virtual int AppointmentId { get; set; }
    }
}
