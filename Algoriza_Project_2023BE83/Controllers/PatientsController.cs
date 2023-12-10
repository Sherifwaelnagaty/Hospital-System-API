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
    }
}
