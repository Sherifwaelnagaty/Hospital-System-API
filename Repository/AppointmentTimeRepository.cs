using Core.Domain;
using Core.Repository;
using Repository.Data;
using System;
using System.Linq;

namespace Repository
{
    public class AppointmentTimeRepository(ApplicationContext context) :
                            DataOperationsRepository<AppointmentTime>(context), IAppointmentTimeRepository
    {
        public bool GetByDayIdAndSlot(int dayId, TimeSpan timeSlot)
        {
            return _context.AppointmentTimes.Any(t => t.AppointmentId == dayId &&
                                                              t.Time == timeSlot);
        }
    }
}
