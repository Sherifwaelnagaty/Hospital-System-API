using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IBookingRepository<T> where T : Booking
    {
        T BookAppointment(T model);
        IEnumerable<T> GetBookingForDoctor(string doctorId);
        IEnumerable<T> GetBookingForPatient(string patientId);
        Task<bool> CancelBookingbyId(string id);
    }
}
