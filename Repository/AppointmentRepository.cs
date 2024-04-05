using Core.Enums;
using Core.Models;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AppointmentRepository:CommonRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationContext context) : base(context)
        {
      
        }
        public Appointment GetByDoctorIdAndDay(int doctorId, Days day)
        {
            return _context.Appointments.FirstOrDefault(a => a.DoctorId == doctorId && a.DayOfWeek == day);
        }

    }
}
