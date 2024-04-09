using Core.DTO;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Drawing.Printing;
namespace Algoriza_Project_2023BE83.Controllers;

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
    //[Authorize (Roles ="Patient")]
    [HttpGet("")]
    public IActionResult GetAllDoctors([FromQuery] int pageNumber, [FromQuery] int pageSize, string search)
    {
        var doctors = _doctorsService.GetAllDoctors(pageNumber, pageSize,search);
        return Ok(doctors);
    }
    //[Authorize (Roles ="Patient")]
    [HttpGet("{id}")]
    public  IActionResult GetDoctorById([FromRoute] int id)
    {
        var doctor =  _doctorsService.GetDoctorById(id);
        if (doctor == null)
        {
            return NotFound();
        }
        return Ok(doctor);
    }

    //[Authorize (Roles ="Admin")]
    [HttpPost("")]
    public IActionResult AddDoctor([FromBody] UserDTO doctorModel)
    {
        if (ModelState.IsValid)
        {
            if (doctorModel.Image != null)
            {
                string folder = "Images/Doctors";
                folder += doctorModel.Image.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);   
            }
            //var id = _doctorsService.AddDoctor(doctorModel);
            //if (id == null)
            //{
                //return BadRequest("An Error has occured");
            //}
            // return CreatedAtAction(nameof(GetDoctorById), new { id = id, controllers = "doctors" }, id);
        }
        return BadRequest("Error Happened");
    }
    //[Authorize (Roles ="Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctorById([FromRoute] int id)
    {
        var doctor = await _doctorsService.DeleteDoctorById(id);
        if(true) 
        {
            return Ok("Doctor's Account Deleted Successfully");
        }
        return BadRequest("An Error has occured");
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
}