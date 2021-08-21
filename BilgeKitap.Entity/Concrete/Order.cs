using BilgeKitap.Core.Entities;
using BilgeKitap.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Entity
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
