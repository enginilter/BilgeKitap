using BilgeKitap.Entity;
using System.Collections.Generic;

namespace BilgeKitap.Business.Abstract
{
    public interface IOrderDetailService
    {
        List<OrderDetail> GetAll();
        void Add(OrderDetail orderDetail);
        void Delete(OrderDetail orderDetail);
        void Update(OrderDetail orderDetail);
        OrderDetail GetByID(int oDetailId);
    }
}
