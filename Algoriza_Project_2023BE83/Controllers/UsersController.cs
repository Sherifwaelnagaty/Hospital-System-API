using Microsoft.AspNetCore.Mvc;
using Algoriza_Project_2023BE83.Models;
using Core.Domain;
using Core.Repository;
using Core.Service;
namespace Algoriza_Project_2023BE83.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IPatientsRepository<Doctors> _patientsService;
    public UsersController(IPatientsRepository<Users> patientsService)
    {
        _patientsService = patientsService;
    }
    [HttpGet("")]
    public async Task<IActionResult> GetAllPatients()
    {
        var patients = await _patientsService.GetAllUsers();
        return Ok(patients);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientById([FromRoute]string id)
    {
        var patient = await _patientsService.GetUserByIdAsync(id);
        if (patient == null)
        {
            return NotFound();
        }
        return Ok(patient);
    }     
}