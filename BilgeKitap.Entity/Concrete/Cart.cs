using BilgeKitap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Entity.Concrete
{
    public class Cart:IEntity
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
