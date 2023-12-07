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
    public async Task<IActionResult> GetAllDoctors(int pageNumber, int pageSize)
    {
        var doctors = _doctorsService.GetAllDoctors(pageNumber, pageSize);
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
    private async Task<string> UploadImage(string folderPath, IFormFile file)
    {

        folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

        await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

        return "/" + folderPath;
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