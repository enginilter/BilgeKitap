using BilgeKitap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Entity.Concrete
{
    public class Log:IEntity
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public DateTime DateTime { get; set; }
        public string Audit { get; set; }
    }
}
