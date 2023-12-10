using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Patients : Base
    {
        public ICollection<Appointment> Appointments { get; set; }
        public string password { get; set; }

    }
}
