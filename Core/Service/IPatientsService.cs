﻿using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IPatientsService:IApplicationUserService
    {
        IActionResult CancelBooking(int BookingId);
        Task<IActionResult> GetAllPatients(int pageNumber, int pageSize, string search);
        IActionResult GetPatientBookings(string Id);
        Task<IActionResult> GetPatientById(string Id);
    }
}
