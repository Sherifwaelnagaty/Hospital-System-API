using Core.Service;

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
