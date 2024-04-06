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
    public class BookingRepository : CommonRepository<Booking>,IBookingRepository
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
            try
            {
                var bookings = _context.Bookings.Where(b => b.PatientId == PatientId);

                // get Appointment info
                var bookingsWithAppointment = bookings.Join(
                                     _context.AppointmentTimes,
                                     b => b.AppointmentTimeId,
                                     at => at.Id,
                                     (b, at) => new
                                     {
                                         b.DoctorId,
                                         b.BookingState,
                                         b.CouponId,
                                         at.AppointmentId,
                                         Time = at.Time.ToString(),
                                     }
                                    ).Join
                                    (
                                        _context.Appointments,
                                        b => b.AppointmentId,
                                        a => a.Id,
                                        (b, a) => new
                                        {
                                            b.DoctorId,
                                            b.BookingState,
                                            b.CouponId,
                                            b.Time,
                                            day = a.DayOfWeek.ToString()
                                        }
                                    );

                // get coupon info -left join-

                var bookingsWithCouponInfo = bookingsWithAppointment.GroupJoin(
                                              _context.Coupons,
                                              booking => booking.CouponId,
                                              coupon => coupon.Id,
                                              (booking, coupon) => new
                                              {
                                                  booking,
                                                  coupon
                                              }).SelectMany(
                                                  coupon => coupon.coupon.DefaultIfEmpty(),
                                                  (b, c) => new
                                                  {
                                                      b.booking.DoctorId,
                                                      b.booking.BookingState,
                                                      b.booking.day,
                                                      b.booking.Time,
                                                      DiscountType = (c == null) ? 0 : c.DiscountType,
                                                      Value = (c == null) ? 0 : c.Value,
                                                      Name = (c == null) ? "No Coupon" : c.Name
                                                  }
                                              );
                // get doctor info
                var bookingsWithDoctorsInfo = bookingsWithCouponInfo.Join(
                                                _context.Doctors,
                                                b => b.DoctorId,
                                                d => d.Id,
                                                (b, d) => new
                                                {
                                                    d.Price,
                                                    d.DoctorUserId,
                                                    d.SpecializationId,
                                                    b.BookingState,
                                                    b.day,
                                                    b.Time,
                                                    b.DiscountType,
                                                    b.Value,
                                                    b.Name
                                                }
                                              ).Join(
                                                _context.Users,
                                                b => b.DoctorUserId,
                                                u => u.Id,
                                                (b, u) => new
                                                {
                                                    u.FullName,
                                                    b.Price,
                                                    u.Image,
                                                    b.SpecializationId,
                                                    BookingState = b.BookingState.ToString(),
                                                    b.day,
                                                    b.Time,
                                                    b.DiscountType,
                                                    b.Value,
                                                    b.Name
                                                }
                                              ).Join(
                                                _context.Specializations,
                                                b => b.SpecializationId,
                                                s => s.Id,
                                                (b, s) => new BookingWithhDoctorDTO
                                                {
                                                    price = b.Price,
                                                    DoctorName = b.FullName,
                                                    ImagePath = b.Image,
                                                    Specialization = s.Name,
                                                    BookingStatus = b.BookingState,
                                                    Day = b.day,
                                                    Time = b.Time,
                                                    DiscountType = b.DiscountType,
                                                    CouponValue = b.Value,
                                                    discoundCodeName = b.Name
                                                }
                                              ).ToList();

                return new OkObjectResult(bookingsWithDoctorsInfo);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Getting Patient's Bookings \n: {ex.Message}")
                {
                    StatusCode = 500
                };
            }
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
