using Core.Domain;
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
        private readonly BookingRepository<Booking> _bookingRepository;
        public BookingService(BookingRepository<Booking> bookingRepository) 
        {
            _bookingRepository = bookingRepository;
        }

        public Booking BookAppointment(Booking model)
        {
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
