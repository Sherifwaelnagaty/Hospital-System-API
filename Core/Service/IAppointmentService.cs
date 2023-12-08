using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAppointmentService
    {
        Appointment AddAppointment(Appointment doctorModel);
        Task<Appointment> UpdateAppointmentById(string id, Appointment doctorModel);
        Task<bool> DeleteAppointmentById(string id);
    }
}
