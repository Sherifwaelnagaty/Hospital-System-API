using Core.Models;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository;
public class CouponsRepository : DataOperationsRepository<Coupons>, ICouponsRepository
{

    public CouponsRepository(ApplicationContext context) : base(context)
    {
    }
    public Coupons GetByName(string CouponName)
    {
        return _context.Coupons.FirstOrDefault(s => s.Code == CouponName);
    }
}