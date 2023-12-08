using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICouponService
    {
        Coupons AddCoupon(Coupons couponModel);
        Task<Coupons> UpdateCoupon(string id, Coupons couponModel);
        Task<bool> DeleteCoupon(string id);
        Task<bool> DeactivateCoupon(string id);
    }
}
