using Core.Models;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Service
{
    public class CouponsService : ICouponService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CouponsService(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        public async Task<IActionResult> AddCoupon(Coupons couponModel)
        {
            try
            {
                couponModel.Id = 0;
                var result = await _unitOfWork.DiscountCodeCoupons.Add(couponModel);

                _unitOfWork.Complete();
                return result;
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult($"{ex.Message} \n {ex.InnerException?.Message}");
            }
        }

        public IActionResult DeactivateCoupon(int id)
        {
            try
            {
                Coupons coupon = _unitOfWork.DiscountCodeCoupons.GetById(id);
                if (coupon == null)
                {
                    return new NotFoundObjectResult($"Id {id} is not found");
                }

                coupon.IsEnabled = false;
                var result = _unitOfWork.DiscountCodeCoupons.Update(coupon);

                _unitOfWork.Complete();
                return result;
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult($"{ex.Message} \n {ex.InnerException?.Message}");
            }
        }

        public IActionResult DeleteCoupon(int Id)
        {
            try
            {
                Coupons coupon = _unitOfWork.DiscountCodeCoupons.GetById(Id);
                if (coupon == null)
                {
                    return new NotFoundObjectResult($"Id {Id} is not found");
                }

                bool IsUsed = _unitOfWork.Bookings.IsExist(b => b.CouponId == Id);
                if (IsUsed)
                {
                    return new BadRequestObjectResult("This coupon is already used, you can't update it");
                }

                var result = _unitOfWork.DiscountCodeCoupons.Delete(coupon);
                _unitOfWork.Complete();
                return result;
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult($"{ex.Message} \n {ex.InnerException?.Message}");
            }
        }

        public IActionResult UpdateCoupon(Coupons couponModel)
        {
            try
            {
                bool IsCouponExist = _unitOfWork.DiscountCodeCoupons.IsExist(c => c.Id == couponModel.Id);
                if (!IsCouponExist)
                {
                    return new NotFoundObjectResult($"Id {couponModel.Id} is not found");
                }

                bool IsUsed = _unitOfWork.Bookings.IsExist(b => b.CouponId == couponModel.Id);
                if (IsUsed)
                {
                    return new BadRequestObjectResult("This coupon is already used, you can't update it");
                }

                var result = _unitOfWork.DiscountCodeCoupons.Update(couponModel);

                _unitOfWork.Complete();
                return result;
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult($"{ex.Message} \n {ex.InnerException?.Message}");
            }
        }

    }
}
