using Core.Domain;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IBookingRepository:ICommonRepository<Booking>
    {
        int NumOfBooKings();
        int NumOfBookings(Expression<Func<Booking, bool>> criteria);
        IActionResult GetPatientBookings(string PatientId);
        public IActionResult GetDoctorBookings(int DoctorId, int Page, int PageSize,
                                Func<BookingWithPatientDTO, bool> criteria = null);
    }
}
