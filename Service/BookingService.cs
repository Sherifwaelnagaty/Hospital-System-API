using Core.Domain;
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
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository<Booking> _bookingRepository;
        private readonly IAppointmentRepository<Appointment> _appointmentRepository;
        public BookingService(IBookingRepository<Booking> bookingRepository, IAppointmentRepository<Appointment> appointmentRepository) 
        {
            _bookingRepository = bookingRepository;
           _appointmentRepository = appointmentRepository;
        }
        public Booking BookAppointment(Booking model)
        {
            _appointmentRepository.DeleteAppointmentById(model.AppointmentId);
            return _bookingRepository.BookAppointment(model);
        }
        public Task<bool> CancelBookingbyId(string id)
        {
            return _bookingRepository.CancelBookingbyId(id);    
        }
        public IEnumerable<Booking> GetBookingForDoctor(string doctorId)
        {
            return _bookingRepository.GetBookingForDoctor(doctorId);
        }
        public IEnumerable<Booking> GetBookingForPatient(string patientId)
        {
            return _bookingRepository.GetBookingForPatient(patientId);
        }
    }
}
