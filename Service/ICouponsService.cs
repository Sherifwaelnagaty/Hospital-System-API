using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICouponsService
    {
        Task<int> AddCoupon(Coupons couponModel);
        Task UpdateCoupon(string id, Coupons couponModel);
        Task DeleteCoupon(string id);
        Task DeactivateCoupon(string id);
    }
}
