using BilgeKitap.Entity;
using System.Collections.Generic;

namespace BilgeKitap.Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll();
        void Add(Order order);
        void Delete(Order order);
        void Update(Order order);
        Order GetByID(int orderlId);
    }
}
