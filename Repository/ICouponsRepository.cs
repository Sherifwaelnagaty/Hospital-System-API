using Core.Models;
using System.Threading.Tasks;

namespace Core.Repository;
public interface ICouponsRepository<T> where T : Coupons 
{
    T AddCoupon(T couponModel);
    Task<T> UpdateCoupon(string id, T couponModel);
    Task<bool> DeleteCoupon(string id);
    Task<bool> DeactivateCoupon(string id);
}