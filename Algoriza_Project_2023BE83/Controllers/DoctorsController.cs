using Core.DTO;
using Core.Enums;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Drawing.Printing;
namespace Algoriza_Project_2023BE83.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorService _doctorsService;
    private readonly IAppointmentTimeServices _appointmentTimeServices;

    public DoctorsController(IDoctorService doctorsService, IAppointmentTimeServices appointmentTimeServices)
    {
        _doctorsService = doctorsService;
        _appointmentTimeServices = appointmentTimeServices;
    }
    //[Authorize (Roles ="Patient")]
    [HttpGet("")]
    public IActionResult GetAllDoctors([FromQuery] int pageNumber, [FromQuery] int pageSize, string search)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return _doctorsService.GetAllDoctors(pageNumber, pageSize, search);
    }
    //[Authorize (Roles ="Patient")]
    [HttpGet("{id}")]
    public  IActionResult GetDoctorById([FromRoute] int id)
    {
        if (id == 0)
        {
            ModelState.AddModelError("Id", "Id is required");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return _doctorsService.GetDoctorById(id);
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> AddDoctor([FromForm] UserDTO userDTO, [FromForm] string Specialize)
    {

        if (string.IsNullOrEmpty(Specialize))
        {
            ModelState.AddModelError("Specialize", "Specialize Is Required");
        }
        if (userDTO.Image == null || userDTO.Image.Length == 0)
        {
            ModelState.AddModelError("userDTO.Image", "Image Is Required");
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        };

        return await _doctorsService.AddDoctor(userDTO, UserRole.Patient, Specialize);
    }

    [HttpPut]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdateDoctorById([FromForm] int id, [FromForm] UserDTO userDTO, [FromForm] string Specialize)
    {
        if (string.IsNullOrEmpty(Specialize))
        {
            ModelState.AddModelError("Specialize", "Specialize Is Required");
        }
        if (userDTO.Image == null || userDTO.Image.Length == 0)
        {
            ModelState.AddModelError("userDTO.Image", "Image Is Required");
        }

        if (id == 0)
        {
            ModelState.AddModelError("Id", "Id Is Required");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        };

        return await _doctorsService.UpdateDoctorById(id, userDTO, Specialize);
    }
    //[Authorize (Roles ="Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctorById([FromRoute] int id)
    {
        try
        {
            if (id == 0)
            {
                ModelState.AddModelError("id", "id Is Required");
            }
            else if (id < 0)
            {
                ModelState.AddModelError("id", "id Is Invalid. Id must be greater than 0");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };
            return await _doctorsService.DeleteDoctorById(id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while Deleting the Doctor:\n" +
                $"  {ex.Message} \n  {ex.Message}");
        }
    }
    [HttpGet("Dashboard/top")]
    public IActionResult GetTopDoctors()
    {
        var Numbers = _doctorsService.GetTopDoctors();
        if (Numbers == null)
        {
            return BadRequest("An Error Has Occured ,Try Again");
        }
        return Ok(Numbers);
    }
    [HttpPost("Appointments")]
    [Authorize(Roles = "Doctor")]
    public async Task<IActionResult> AddAppointments(AppointmentsDTO appointments)
    {
        if (appointments == null)
        {
            return BadRequest("Price and appointment are required");

        }

        if (appointments.Price <= 0)
        {
            return BadRequest("Invalid Price");
        }

        if (appointments.days == null)
        {
            return BadRequest("Appointments is required");
        }

        string? doctorId = (User.Claims.FirstOrDefault(c => c.Type == "DoctorId")?.Value);

        if (int.TryParse(doctorId, out int id))
        {
            return _doctorsService.AddAppointments(id, appointments);
        }
        else
        {
            return new ObjectResult("There is a problem in current user data\n Invalid DoctorId")
            {
                StatusCode = 500
            };
        }
    }

    [HttpPatch("Appointment")]
    [Authorize(Roles = "Doctor")]
    public IActionResult DeleteAppointment([FromForm] int TimeId, [FromForm] string NewTime)
    {
        if (TimeId == 0)
        {
            ModelState.AddModelError("TimeId", "Time Id is required");
        }

        if (string.IsNullOrEmpty(NewTime))
        {
            ModelState.AddModelError("NewTime", "NewTime Id is required");
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return _appointmentTimeServices.UpdateAppointment(TimeId, NewTime);
    }

    [HttpDelete("Appointment")]
    [Authorize(Roles = "Doctor")]
    public IActionResult DeleteAppointment([FromForm] int TimeId)
    {
        if (TimeId == 0)
        {
            ModelState.AddModelError("TimeId", "Time Id is required");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return _appointmentTimeServices.DeleteAppointment(TimeId);
    }
}