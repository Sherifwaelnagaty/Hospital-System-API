using Core.Domain;
using Core.Models;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        public IDoctorsRepository Doctors { get; }
        public IApplicationUserRepository ApplicationUser { get; }
        public ICouponsRepository DiscountCodeCoupons { get; }
        public IAppointmentTimeRepository AppointmentTimes { get; }
        public IAppointmentRepository Appointments { get; }
        public IBookingRepository Bookings { get; }
        public ISpecializationRepository Specializations { get; }
        public IPatientsRepository Patients { get; }
        int Complete();
    }
}
