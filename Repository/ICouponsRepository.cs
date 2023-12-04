using Core.Domain;
using System.Threading.Tasks;

namespace Core.Repository;
public interface ICouponsRepository
{
    Task<int> AddCoupon(Coupons couponModel);
    Task UpdateCoupon(int id, Coupons couponModel);
    Task DeleteCoupon(int id);
    Task DeactivateCoupon(int id);
}