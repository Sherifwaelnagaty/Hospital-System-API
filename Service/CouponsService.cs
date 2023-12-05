using Core.Domain;
using Repository;
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

        public Task<int> AddCoupon(Coupons couponModel)
        {
            return _couponsRepository.AddCoupon(couponModel);
        }

        public Task DeactivateCoupon(string id)
        {
            return _couponsRepository.DeactivateCoupon(id);   
        }

        public Task DeleteCoupon(string id)
        {
            return _couponsRepository.DeleteCoupon(id);
        }

        public Task UpdateCoupon(string id, Coupons couponModel)
        {
            return _couponsRepository.UpdateCoupon(id,couponModel);
        }
    }
}
