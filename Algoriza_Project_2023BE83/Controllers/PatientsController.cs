using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
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

        public PatientsController(IPatientsService PatientServices,
            IBookingService bookingsServices, IDoctorService doctorServices)
        {
            _PatientsService = PatientServices;
            _bookingsServices = bookingsServices;
            _doctorServices = doctorServices;
        }
        [HttpGet("")]
        public IActionResult GetAllPatients([FromRoute]int pageNumber,[FromRoute] int pageSize)
        {
            var Patients = _PatientsService.GetAllPatients(pageNumber, pageSize);
            return Ok(Patients);
        }
        [HttpGet("{id}")]
        public IActionResult GetPatientById([FromRoute] string id)
        {
            var Patient = _PatientsService.GetPatientById(id);
            if (Patient == null)
            {
                return NotFound();
            }
            return Ok(Patient);
        }
        [HttpGet("Dahsboard/Numbers")]
        public IActionResult GetNumberofPatients()
        {
            var Numbers = _PatientsService.GetNumbersofPatients();
            if(Numbers == null)
            {
                return BadRequest("An Error Has Occured ,Try Again");
            }
            return Ok(Numbers);
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
        public IActionResult AddBooking([FromForm] int TimeId, [FromForm] string? CouponName)
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
