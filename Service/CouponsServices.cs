using Algoriza_Project_2023BE83.Data;
using Algoriza_Project_2023BE83.Models;
using Core.Domain;
using Core.Service;
namespace Service.Data;
public class CouponsServices : ICouponsService
{
    private readonly CouponsContext _context;
    public CouponsServices(CouponsContext context)
    {
        _context = context;
    }
    public async Task<int> AddCoupon(Coupons couponModel)
    {
        var coupon = new Coupons()
        {
            Code = couponModel.Code,
            DiscountType = couponModel.DiscountType,
            MaxUses = couponModel.MaxUses,
            Uses = 0,
            ExpirationDate = couponModel.ExpirationDate,
            IsEnabled = couponModel.IsEnabled,
            Value = couponModel.Value
        };
        _context.Coupons.Add(coupon);
        await _context.SaveChangesAsync();
        return coupon.Id;
    }
    public async Task UpdateCoupon(int id, Coupons couponModel)
    {
        var coupon = await _context.Coupons.FindAsync(id);
        coupon.Code = couponModel.Code;
        coupon.DiscountType = couponModel.DiscountType;
        coupon.MaxUses = couponModel.MaxUses;
        coupon.Uses = couponModel.Uses;
        coupon.ExpirationDate = couponModel.ExpirationDate;
        coupon.IsEnabled = couponModel.IsEnabled;
        coupon.Value = couponModel.Value;
        await _context.SaveChangesAsync();
    }
    public async Task DeleteCoupon(int id)
    {
        var coupon = await _context.Coupons.FindAsync(id);
        _context.Coupons.Remove(coupon);
        await _context.SaveChangesAsync();
    }
    public async Task DeactivateCoupon(int id)
    {
        var coupon = await _context.Coupons.FindAsync(id);
        coupon.IsEnabled = false;
        await _context.SaveChangesAsync();
    }
}