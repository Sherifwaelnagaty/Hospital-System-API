using Core.DTO;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAppointmentService
    {
        IActionResult AddDays(int doctorId, List<Day> appointments);
    }
}
