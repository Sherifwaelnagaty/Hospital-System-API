using Microsoft.AspNetCore.Mvc;
using Algoriza_Project_2023BE83.Models;
using Core.Domain;
using Core.Repository;
namespace Algoriza_Project_2023BE83.Controllers;
[Route("api/[controller]")]
[ApiController]
class DoctorsController : ControllerBase
{
    private readonly IDoctorsRepository<Doctors> _doctorsRepository;
    public DoctorsController(IDoctorsRepository<Doctors> doctorsRepository)
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
    public async Task<IActionResult> GetDoctorById([FromRoute]string id)
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
    public async Task<IActionResult> UpdateDoctorById([FromRoute] string id, [FromBody] Doctors doctorModel, IDoctorsRepository<Doctors> _doctorsRepository)
    {
        var doctor = await _doctorsRepository.UpdateDoctorById(id, doctorModel);
        return Ok(doctor);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctorById([FromRoute] string id)
    {
        var doctor = await _doctorsRepository.DeleteDoctorById(id);
        return Ok(doctor);
    }
}