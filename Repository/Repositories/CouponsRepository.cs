using Core.Models;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Threading.Tasks;

namespace Repository.Repositories;
public class CouponsRepository<T> : ICouponsRepository<T> where T : Coupons
{
    private readonly ApplicationContext _context;
    private DbSet<T> entities;
    public CouponsRepository(ApplicationContext context)
    {
        _context = context;
        entities = context.Set<T>();
    }
    public T AddCoupon(T couponModel)
    {
        if(couponModel!=null) 
        {
          entities.Add(couponModel);
          _context.SaveChangesAsync();
            return couponModel;
        }
        else
        {
            throw new Exception("There's something wrong in your Input try again");
        }
         
    }
    public async Task<T> UpdateCoupon(string id, T couponModel)
    {
        var coupon = await entities.FindAsync(id);
        if (coupon != null)
        {
            coupon.Code = couponModel.Code;
            coupon.DiscountType = couponModel.DiscountType;
            coupon.MaxUses = couponModel.MaxUses;
            coupon.Uses = couponModel.Uses;
            coupon.IsEnabled = couponModel.IsEnabled;
            coupon.Value = couponModel.Value;
            await _context.SaveChangesAsync();
            return coupon;
        }
        else
        {
            throw new Exception("Coupon not found");
        }
    }
    public async Task<bool> DeleteCoupon(string id)
    {
        var coupon = await entities.FindAsync(id);
        if (coupon != null)
        {
            entities.Remove(coupon);
            await _context.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public async Task<bool> DeactivateCoupon(string id)
    {
        var coupon = await entities.FindAsync(id);
        if (coupon != null)
        {
            coupon.IsEnabled = false;
            await _context.SaveChangesAsync();
            return true;
        }
        else 
        {
            return false; 
        }
    }
}