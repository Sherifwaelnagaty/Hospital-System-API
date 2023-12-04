using Microsoft.AspNetCore.Mvc;
using Algoriza_Project_2023BE83.Models;
using Algoriza_Project_2023BE83.Data;
using Core.Service;
using Core.Domain;
namespace Algoriza_Project_2023BE83.Controllers;
[Route("api/[controller]")]
[ApiController]
class DoctorsController : ControllerBase
{
    private readonly IDoctorsService _doctorsRepository;
    public DoctorsController(IDoctorsService doctorsRepository)
    {
        _doctorsRepository = doctorsRepository;
    }
    [HttpGet("")]
    public async Task<IActionResult> GetAllDoctors()
    {
        var doctors = await _doctorsRepository.GetAllDoctors();
        return Ok(doctors);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctorById([FromRoute]int id)
    {
        var doctor = await _doctorsRepository.GetDoctorById(id);
        if (doctor == null)
        {
            return NotFound();
        }
        return Ok(doctor);
    }
    [HttpPost("")]
    public async Task<IActionResult> AddDoctor([FromBody] Doctors doctorModel)
    {
        var id = await _doctorsRepository.AddDoctor(doctorModel);
        return CreatedAtAction(nameof(GetDoctorById), new { id = id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDoctorById([FromRoute] int id, [FromBody] Doctors doctorModel, IDoctorsService _doctorsRepository)
    {
        //var doctor = await _doctorsRepository.UpdateDoctorById(id, doctorModel);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctorById([FromRoute] int id)
    {
        //var doctor = await _doctorsRepository.DeleteDoctorById(id);
        return Ok();
    }
}