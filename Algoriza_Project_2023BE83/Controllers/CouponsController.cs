using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using Core.Models;
namespace Algoriza_Project_2023BE83.Controllers;
//[Authorize(Roles ="Admin")]
[Route("api/[controller]")]
[ApiController]
public class CouponsController : ControllerBase
{
    private readonly ICouponService _couponsRepository;
    public CouponsController(ICouponService couponsRepository)
    {
        _couponsRepository = couponsRepository;
    }
    [HttpPost("")]
    public async Task<IActionResult> AddCoupon([FromBody] Coupons couponModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        };

        return await _couponsRepository.AddCoupon(couponModel);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCoupon([FromBody]Coupons couponModel)
    {
        if (couponModel == null)
        {
            ModelState.AddModelError("DiscountCodeCoupon", "The DiscountCodeCoupon is required.");
        }
        else if (couponModel.Id == default)
        {
            ModelState.AddModelError("Id", "The Id is required.");
        }

        else if (couponModel.Id < 0)
        {
            ModelState.AddModelError("Id", "The Id is Invalid. Must be greater than 0.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        };

        return _couponsRepository.UpdateCoupon(couponModel);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCoupon([FromForm]int id)
    {
        if(id <= 0)
            {
            ModelState.AddModelError("id", "The Id is Invalid. Must be greater than 0.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        };

        return _couponsRepository.DeleteCoupon(id);
    }
    [HttpPut("deactivate/{id}")]
    public async Task<IActionResult> DeactivateCoupon([FromForm]int id)
    {
        if (id <= 0)
        {
            ModelState.AddModelError("id", "The Id is Invalid. Must be greater than 0.");
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        };

        return _couponsRepository.DeactivateCoupon(id);
    }
}