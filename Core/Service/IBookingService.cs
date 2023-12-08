using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IBookingService
    {
        Booking BookAppointment(Booking model);
        IEnumerable<Booking> GetBookingForDoctor(string doctorId);
        IEnumerable<Booking> GetBookingForPatient(string patientId);
        Task<bool> CancelBookingbyId(string id);
    }
}
