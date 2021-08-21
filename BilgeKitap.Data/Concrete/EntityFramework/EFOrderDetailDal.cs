using BilgeKitap.Core.DataAccess.EntityFramework.Concrete;
using BilgeKitap.Data.Abstract;
using BilgeKitap.Data.Concrete.EntityFramework;
using BilgeKitap.Entity;

namespace BilgeKitap.Data.Concrete
{
    public class EFOrderDetailDal: EFEntityRepositoryBase<OrderDetail, BKContext>,IOrderDetailDal
    {
    }

}
