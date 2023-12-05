using Microsoft.AspNetCore.Mvc;
using Algoriza_Project_2023BE83.Models;
using Core.Domain;
using Core.Repository;
namespace Algoriza_Project_2023BE83.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CouponsController : ControllerBase
{
    private readonly ICouponsRepository<Coupons> _couponsRepository;
    public CouponsController(ICouponsRepository<Coupons> couponsRepository)
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
    public async Task<IActionResult> UpdateCoupon(string id, [FromBody] Coupons couponModel)
    {
        await _couponsRepository.UpdateCoupon(id, couponModel);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCoupon(string id)
    {
        await _couponsRepository.DeleteCoupon(id);
        return Ok();
    }
    [HttpPut("deactivate/{id}")]
    public async Task<IActionResult> DeactivateCoupon(string id)
    {
        await _couponsRepository.DeactivateCoupon(id);
        return Ok();
    }
}