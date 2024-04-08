using Core.Domain;
using Core.DTO;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public class BookingRepository : CommonRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationContext context):base(context) 
        {

        }

        public IActionResult GetDoctorBookings(int DoctorId, int Page, int PageSize, Func<BookingWithPatientDTO, bool> criteria = null)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetPatientBookings(string PatientId)
        {
            throw new NotImplementedException();
        }

        public int NumOfBooKings()
        {
            return _context.Bookings.Count();
        }

        public int NumOfBookings(Expression<Func<Booking, bool>> criteria)
        {
            return _context.Bookings.Count(criteria);
        }
    }
}
