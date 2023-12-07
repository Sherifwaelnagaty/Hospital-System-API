using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
namespace Algoriza_Project_2023BE83.Controllers;
[Authorize (Roles ="Admin")]
[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorService _doctorsService;
    public DoctorsController(IDoctorService doctorsService)
    {
        _doctorsService = doctorsService;
    }
    [HttpGet("")]
    public async Task<IActionResult> GetAllDoctors()
    {
        var doctors = _doctorsService.GetAllDoctors();
        return Ok(doctors);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctorById([FromRoute]string id)
    {
        var doctor =  _doctorsService.GetDoctorById(id);
        if (doctor == null)
        {
            return NotFound();
        }
        return Ok(doctor);
    }
    [HttpPost("")]
    public async Task<IActionResult> AddDoctor([FromBody] Doctors doctorModel)
    {
        var id = _doctorsService.AddDoctor(doctorModel);
        if (id == null) 
        {
            return BadRequest("An Error has occured");
        }
        return CreatedAtAction(nameof(GetDoctorById), new { id = id, controllers = "doctors" },id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDoctorById([FromRoute] string id, [FromBody] Doctors doctorModel, IDoctorService _doctorsService)
    {
        var doctor = await _doctorsService.UpdateDoctorById(id, doctorModel);
        return Ok(doctor);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctorById([FromRoute] string id)
    {
        var doctor = await _doctorsService.DeleteDoctorById(id);
        if(doctor==true) 
        {
            return Ok("Doctor's Account Deleted Successfully");
        }
        return BadRequest("An Error has occured");
    }
}