using BilgeKitap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Entity
{
   public class Author:IEntity
    {
        public int AuthorId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string  PhoneNumber { get; set; }
        public string AuthorEmail { get; set; }
        public virtual ICollection<Book>Books { get; set; }

    }
}
