using Core.Models;
using Core.Repository;
using Core.Service;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppointmentRepository<Appointment> _appointmentrepository;
        public AppointmentService(AppointmentRepository<Appointment> appointmentrepository) 
        {
            _appointmentrepository = appointmentrepository;
        }
        public Appointment AddAppointment(Appointment doctorModel)
        {
            return _appointmentrepository.AddAppointment(doctorModel);
        }

        public Task<bool> DeleteAppointmentById(string id)
        {
            return _appointmentrepository.DeleteAppointmentById(id);
        }

        public Task<Appointment> UpdateAppointmentById(string id, Appointment doctorModel)
        {
            return _appointmentrepository.UpdateAppointmentById(id, doctorModel);
        }
    }
}
