using Core.Models;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Service;

public class AppointmentController : ControllerBase 
{
    private readonly IAppointmentService _appointmentRepository;
    public AppointmentController(IAppointmentService appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }
    [HttpPost("")]
    public IActionResult AddAppointment([FromBody] Appointment AppointmentModel)
    {
        var couponId = _appointmentRepository.AddAppointment(AppointmentModel);
        return Ok(couponId);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAppointmentById(string id, [FromBody] Appointment AppointmentModel)
    {
        await _appointmentRepository.UpdateAppointmentById(id, AppointmentModel);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointmentById(string id)
    {
        await _appointmentRepository.DeleteAppointmentById(id);
        return Ok("Coupon Deleted Successfully");
    }
}