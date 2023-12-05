using Core.Domain;
using System.Threading.Tasks;

namespace Core.Repository;
public interface ICouponsRepository<T> where T : Coupons
{
    Task<int> AddCoupon(Coupons couponModel);
    Task UpdateCoupon(string id, Coupons couponModel);
    Task DeleteCoupon(string id);
    Task DeactivateCoupon(string id);
}