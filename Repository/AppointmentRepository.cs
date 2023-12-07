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
    public class AppointmentRepository<T>: IAppointmentRepository<T> where T: Appointment
    {
        private readonly ApplicationContext _context;
        private DbSet<T> entities;
        public AppointmentRepository(ApplicationContext context) 
        {
            _context = context;
            entities = context.Set<T>();
        }

        public T AddAppointment(T Model)
        {
            if (Model == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(Model);
            _context.SaveChanges();
            return Model;
        }

        public async Task<bool> DeleteAppointmentById(string id)
        {
            var Appointment = await entities.FindAsync(id);
            if (Appointment != null)
            {
                entities.Remove(Appointment);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<T> UpdateAppointmentById(string id, T Model)
        {
            var Appointment = await entities.FindAsync(id);
            if (Appointment != null)
            {
                Appointment.Time = Model.Time;
                Appointment.Date = Model.Date;
                Appointment.Price = Model.Price;
                Appointment.Days = Model.Days;
                Appointment.Date = Model.Date;
                await _context.SaveChangesAsync();
                return Appointment;
            }
            else
            {
                throw new Exception("Coupon not found");
            }
        }
    }
}
