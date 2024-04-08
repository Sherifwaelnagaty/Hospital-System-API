using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICouponService
    {
        Task<IActionResult> AddCoupon(Coupons couponModel);
        IActionResult UpdateCoupon(Coupons couponModel);
        IActionResult DeleteCoupon(int id);
        IActionResult DeactivateCoupon(int id);
    }
}
