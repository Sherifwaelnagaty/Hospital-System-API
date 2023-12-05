using Microsoft.AspNetCore.Mvc;
using Algoriza_Project_2023BE83.Models;
using Core.Domain;
using Service;
namespace Algoriza_Project_2023BE83.Controllers;
[Route("api/[controller]")]
[ApiController]
class DoctorsController : ControllerBase
{
    private readonly IDoctorService _doctorsService;
    public DoctorsController(IDoctorService doctorsService)
    {
        _doctorsService = doctorsService;
    }
    [HttpGet("")]
    public async Task<IActionResult> GetAllDoctors()
    {
        var doctors = await _doctorsService.GetAllDoctors();
        return Ok(doctors);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctorById([FromRoute]string id)
    {
        var doctor = await _doctorsService.GetDoctorById(id);
        if (doctor == null)
        {
            return NotFound();
        }
        return Ok(doctor);
    }
    [HttpPost("")]
    public async Task<IActionResult> AddDoctor([FromBody] Doctors doctorModel)
    {
        var id = await _doctorsService.AddDoctor(doctorModel);
        return CreatedAtAction(nameof(GetDoctorById), new { id = id });
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
        return Ok(doctor);
    }
}