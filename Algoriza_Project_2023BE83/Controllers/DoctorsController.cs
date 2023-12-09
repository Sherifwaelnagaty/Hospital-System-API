using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Drawing.Printing;
namespace Algoriza_Project_2023BE83.Controllers;
[Authorize (Roles ="Admin")]
[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorService _doctorsService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public DoctorsController(IDoctorService doctorsService, IWebHostEnvironment webHostEnvironment)
    {
        _doctorsService = doctorsService;
        _webHostEnvironment = webHostEnvironment;
    }
    [HttpGet("")]
    public IActionResult GetAllDoctors(int pageNumber, int pageSize)
    {
        var doctors = _doctorsService.GetAllDoctors(pageNumber, pageSize);
        return Ok(doctors);
    }
    [HttpGet("{id}")]
    public  IActionResult GetDoctorById([FromRoute]string id)
    {
        var doctor =  _doctorsService.GetDoctorById(id);
        if (doctor == null)
        {
            return NotFound();
        }
        return Ok(doctor);
    }
    [HttpPost("")]
    public IActionResult AddDoctor([FromBody] Doctors doctorModel)
    {
        if (ModelState.IsValid)
        {
            if (doctorModel.Image != null)
            {
                string folder = "Images/Doctors";
                folder += doctorModel.Image.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);   
            }
            var id = _doctorsService.AddDoctor(doctorModel);
            if (id == null)
            {
                return BadRequest("An Error has occured");
            }
            return CreatedAtAction(nameof(GetDoctorById), new { id = id, controllers = "doctors" }, id);
        }
        return BadRequest("Error Happened");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDoctorById([FromRoute] string id, [FromBody] Doctors doctorModel)
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
    [HttpGet("Dashboard/{id}")]
    public IActionResult GetNumbersofDoctors()
    {
        var Numbers = _doctorsService.GetNumberOfDoctors();
        if (Numbers == null)
        {
            return BadRequest("An Error Has Occured ,Try Again");
        }
        return Ok(Numbers);
    }
    [HttpGet("Dashboard/")]
    public IActionResult GetTopDoctors()
    {
        var Numbers = _doctorsService.GetTopDoctors();
        if (Numbers == null)
        {
            return BadRequest("An Error Has Occured ,Try Again");
        }
        return Ok(Numbers);
    }
}