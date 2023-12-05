using Core.Domain;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repository;
public class CouponsRepository<T> : ICouponsRepository<T> where T : Coupons
{
    private readonly ApplicationContext _context;
    private DbSet<T> entities;
    public CouponsRepository(ApplicationContext context)
    {
        _context = context;
        entities = context.Set<T>();
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
        entities.Add((T)coupon);
        await _context.SaveChangesAsync();
        return coupon.Id;
    }
    public async Task UpdateCoupon(string id, Coupons couponModel)
    {
        var coupon = await entities.FindAsync(id);
        coupon.Code = couponModel.Code;
        coupon.DiscountType = couponModel.DiscountType;
        coupon.MaxUses = couponModel.MaxUses;
        coupon.Uses = couponModel.Uses;
        coupon.ExpirationDate = couponModel.ExpirationDate;
        coupon.IsEnabled = couponModel.IsEnabled;
        coupon.Value = couponModel.Value;
        await _context.SaveChangesAsync();
    }
    public async Task DeleteCoupon(string id)
    {
        var coupon = await entities.FindAsync(id);
        if (coupon != null)
        {
            entities.Remove(coupon);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeactivateCoupon(string id)
    {
        var coupon = await entities.FindAsync(id);
        if (coupon != null)
        {
            coupon.IsEnabled = false;
            await _context.SaveChangesAsync();
        }
    }


}