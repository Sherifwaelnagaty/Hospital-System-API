using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IAppointmentRepository<T> where T : Appointment
    {
        T AddAppointment(T doctorModel);
        Task<T> UpdateAppointmentById(string id, T doctorModel);
        Task<bool> DeleteAppointmentById(string id);
    }
}
