using Algoriza_Project_2023BE83.Models;
using Core.Domain;
namespace Core.Service;
public interface ICouponsService
{
    Task<int> AddCoupon(Coupons couponModel);
    Task UpdateCoupon(int id, Coupons couponModel);
    Task DeleteCoupon(int id);
    Task DeactivateCoupon(int id);
}