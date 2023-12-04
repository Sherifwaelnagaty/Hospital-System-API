using Core.Domain;
using Core.Repository;
using System.Threading.Tasks;

namespace Repository;
public class CouponsRepository : ICouponsRepository
{
    private readonly ApplicationContext _context;
    public CouponsRepository(ApplicationContext context)
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
        _context.Add(coupon);
        await _context.SaveChangesAsync();
        return coupon.Id;
    }
    public async Task UpdateCoupon(System.Type id, Coupons couponModel)
    {
        var coupon = await _context.FindAsync(id);
        //coupon.Code = couponModel.Code;
        //coupon.DiscountType = couponModel.DiscountType;
        //coupon.MaxUses = couponModel.MaxUses;
        //coupon.Uses = couponModel.Uses;
        //coupon.ExpirationDate = couponModel.ExpirationDate;
        //coupon.IsEnabled = couponModel.IsEnabled;
        //coupon.Value = couponModel.Value;
        await _context.SaveChangesAsync();
    }
    public async Task DeleteCoupon(System.Type id)
    {
        var coupon = await _context.FindAsync(id);
        _context.Remove(coupon);
        await _context.SaveChangesAsync();
    }
    public async Task DeactivateCoupon(System.Type id)
    {
        var coupon = await _context.FindAsync(id);
        //coupon.IsEnabled = false;
        await _context.SaveChangesAsync();
    }

    public Task UpdateCoupon(int id, Coupons couponModel)
    {
        throw new System.NotImplementedException();
    }

    public Task DeleteCoupon(int id)
    {
        throw new System.NotImplementedException();
    }

    public Task DeactivateCoupon(int id)
    {
        throw new System.NotImplementedException();
    }
}