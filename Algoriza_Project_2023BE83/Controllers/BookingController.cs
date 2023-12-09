using Core.Domain;
using Core.Models;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Algoriza_Project_2023BE83.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController:ControllerBase
    {
        private readonly IBookingService _bookingService;
        
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet("{id}")]
        public IActionResult BookAppointment(Booking model)
        {
            var booked = _bookingService.BookAppointment(model);
            return Ok(booked);
        }
        [HttpGet("doctor/{id}")]
        public IActionResult GetBookingForDoctor(string doctorId)
        {
             var booked = _bookingService.GetBookingForDoctor(doctorId);
             return Ok(booked);
        }
        [HttpGet("patient/{id}")]
        public IActionResult GetBookingForPatient(string patientId)
        {
            var booked = _bookingService.GetBookingForPatient(patientId);
            return Ok(booked);
        }
        [HttpGet("cancel/{id}")]
        public IActionResult CancelBookingbyId(string id)
        {
            var canceling = _bookingService.CancelBookingbyId(id);
            return Ok(canceling);
        }
    }
}
