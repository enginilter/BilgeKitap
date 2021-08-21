
using BilgeKitap.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BilgeKitap.Entity
{
   public class OrderDetail : IEntity
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime OrderDate { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
