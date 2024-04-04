using Core.Models;
using System.Threading.Tasks;

namespace Core.Repository;
public interface ICouponsRepository: IDataOperationsRepository<Coupons>
{
     Coupons GetByName(string CouponName);
}