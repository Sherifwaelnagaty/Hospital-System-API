using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IBookingService
    {
        IActionResult NumOfBookings();
        IActionResult AddBookingToPatient(string PatientId, int AppointmentTimeId, string DiscountCodeCouponName);
    }
}
