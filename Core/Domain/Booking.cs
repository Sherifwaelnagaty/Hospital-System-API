using Core.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Booking
    {
        public string Id { get; set; }
        public DateTime Date { get; set; } 
        public decimal Price { get; set; }
        public virtual Appointment Appointment { get; set; }
        public int PatientId { get; set; }
        public Patients Patient { get; set; }


    }
}
