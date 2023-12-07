using Core.Models;
using Repository;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CouponsService : ICouponsService
    {
        private readonly CouponsRepository<Coupons> _couponsRepository;
        public CouponsService(CouponsRepository<Coupons> couponsRepository) 
        {
            _couponsRepository = couponsRepository;
        }
        public Coupons AddCoupon(Coupons couponModel)
        {
        return _couponsRepository.AddCoupon(couponModel);
        }

        public Task<bool> DeactivateCoupon(string id)
        {
            return _couponsRepository.DeactivateCoupon(id);   
        }

        public Task<bool> DeleteCoupon(string id)
        {
            return _couponsRepository.DeleteCoupon(id);
        }

        public async Task<Coupons> UpdateCoupon(string id, Coupons couponModel)
        {
            return await _couponsRepository.UpdateCoupon(id, couponModel);
        }

    }
}
