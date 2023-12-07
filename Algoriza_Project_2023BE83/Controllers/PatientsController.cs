using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Algoriza_Project_2023BE83.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsService _PatientsService;
        public PatientsController(IPatientsService PatientsService)
        {
            _PatientsService = PatientsService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllPatients(int pageNumber, int pageSize)
        {
            var Patients = _PatientsService.GetAllPatients(pageNumber, pageSize);
            return Ok(Patients);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById([FromRoute] string id)
        {
            var Patient = _PatientsService.GetPatientById(id);
            if (Patient == null)
            {
                return NotFound();
            }
            return Ok(Patient);
        }
    }
}
