using Core.Domain;
using Core.Models;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Algoriza_Project_2023BE83.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController:ControllerBase
    {
        private readonly IBookingService _bookingService;
        
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        //[Authorize(Roles = "Patient")]
        [HttpGet("{id}")]
        public IActionResult BookAppointment([FromBody] Booking model)
        {
            if (ModelState.IsValid)
            {
                var booked = _bookingService.BookAppointment(model);
                return Ok(booked);
            }
            else
            {
                return BadRequest("An Error has occured");
            }
        }
        //[Authorize(Roles = "Doctor")]
        [HttpGet("doctor/{id}")]
        public IActionResult GetBookingForDoctor(string doctorId)
        {
             var booked = _bookingService.GetBookingForDoctor(doctorId);
             return Ok(booked);
        }
        //[Authorize(Roles = "Patient")]
        [HttpGet("patient/{id}")]
        public IActionResult GetBookingForPatient(string patientId)
        {
            var booked = _bookingService.GetBookingForPatient(patientId);
            return Ok(booked);
        }
        //[Authorize(Roles = "Patient")]
        [HttpDelete("cancel/{id}")]
        public IActionResult CancelBookingbyId(string id)
        {
            var canceling = _bookingService.CancelBookingbyId(id);
            return Ok(canceling);
        }
    }
}
