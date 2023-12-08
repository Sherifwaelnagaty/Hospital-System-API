using Core.Domain;
using Core.Models;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace Repository
{
    public class BookingRepository<T> : IBookingRepository<T> where T : Booking
    {
        private readonly ApplicationContext _context;
        private DbSet<T> entities;
        public BookingRepository(ApplicationContext context) 
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public T BookAppointment(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(model);
            _context.SaveChanges();
            return model;
        }

        public async Task<bool> CancelBookingbyId(string id)
        {
            var booking = await entities.FindAsync(id);
            if(booking == null)
            {
                return false;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public IEnumerable<T> GetBookingForDoctor(string doctorId)
        {
            return entities.Where(a => a.DoctorId == doctorId).AsEnumerable();
        }

        public IEnumerable<T> GetBookingForPatient(string patientId)
        {
            return entities.Where(a => a.PatientId == patientId).AsEnumerable();
        }
    }
}
