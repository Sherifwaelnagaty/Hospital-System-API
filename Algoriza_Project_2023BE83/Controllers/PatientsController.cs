using AutoMapper;
using Core.Enums;
using Core.Service;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Drawing.Printing;
using System.Security.Claims;

namespace Algoriza_Project_2023BE83.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPatientsService _PatientsService;
        private readonly IBookingService _bookingsServices;
        private readonly IDoctorService _doctorServices;
        private readonly IApplicationUserService _applicationUserService;

        public PatientsController(IPatientsService PatientServices,
            IBookingService bookingsServices, IDoctorService doctorServices, 
            IApplicationUserService applicationUserService)
        {
            _PatientsService = PatientServices;
            _bookingsServices = bookingsServices;
            _doctorServices = doctorServices;
            _applicationUserService = applicationUserService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllPatients(int pageNumber,int pageSize,string search)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _PatientsService.GetAllPatients(pageNumber, pageSize, search);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _PatientsService.GetPatientById(id);
        }
        [HttpGet("Dahsboard/Numbers")]
        public IActionResult GetNumberOfPatients()
        {
            string Role = Enum.GetName(UserRole.Patient);

            return _applicationUserService.GetUsersCountInRole(Role).Result;
        }
        [HttpGet("Bookings")]
        [Authorize(Roles = "Patient")]
        public IActionResult GetPatientBookings()
        {
            string? PatientId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return _PatientsService.GetPatientBookings(PatientId);
        }

        [HttpPatch("Booking/Cancel")]
        [Authorize(Roles = "Patient")]
        public IActionResult CancelBooking([FromForm] int BookingId)
        {
            return _PatientsService.CancelBooking(BookingId);
        }

        [HttpPost("Booking")]
        [Authorize(Roles = "Patient")]
        public IActionResult AddBooking([FromForm] int TimeId, [FromForm] string CouponName)
        {

            if (TimeId == 0)
            {
                ModelState.AddModelError("TimeId", "TimeId is required");
            }
            else if (TimeId < 0)
            {
                ModelState.AddModelError("TimeId", "TimeId is invalid");
            }
            string? PatientId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return _bookingsServices.AddBookingToPatient(PatientId, TimeId, CouponName);
        }
    }
}
