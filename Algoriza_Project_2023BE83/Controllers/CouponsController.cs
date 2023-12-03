using Microsoft.AspNetCore.Mvc;
using Algoriza_Project_2023BE83.Models;
using Algoriza_Project_2023BE83.Data;
using Core.Service;
using Core.Domain;
namespace Algoriza_Project_2023BE83.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CouponsController : ControllerBase
{
    private readonly ICouponsService _couponsRepository;
    public CouponsController(ICouponsService couponsRepository)
    {
        _couponsRepository = couponsRepository;
    }
    [HttpPost("")]
    public async Task<IActionResult> AddCoupon([FromBody] Coupons couponModel)
    {
        var couponId = await _couponsRepository.AddCoupon(couponModel);
        return Ok(couponId);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCoupon(int id, [FromBody] Coupons couponModel)
    {
        await _couponsRepository.UpdateCoupon(id, couponModel);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCoupon(int id)
    {
        await _couponsRepository.DeleteCoupon(id);
        return Ok();
    }
    [HttpPut("deactivate/{id}")]
    public async Task<IActionResult> DeactivateCoupon(int id)
    {
        await _couponsRepository.DeactivateCoupon(id);
        return Ok();
    }
}