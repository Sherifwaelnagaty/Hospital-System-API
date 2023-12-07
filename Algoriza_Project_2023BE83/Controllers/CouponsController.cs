using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
namespace Algoriza_Project_2023BE83.Controllers;
[Authorize(Roles ="Admin")]
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
        var couponId = _couponsRepository.AddCoupon(couponModel);
        return Ok(couponId);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCoupon(string id, [FromBody] Coupons couponModel)
    {
        await _couponsRepository.UpdateCoupon(id, couponModel);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCoupon(string id)
    {
        await _couponsRepository.DeleteCoupon(id);
        return Ok("Coupon Deleted Successfully");
    }
    [HttpPut("deactivate/{id}")]
    public async Task<IActionResult> DeactivateCoupon(string id)
    {
        await _couponsRepository.DeactivateCoupon(id);
        return Ok();
    }
}