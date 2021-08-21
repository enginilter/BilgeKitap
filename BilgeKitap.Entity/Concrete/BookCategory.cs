using BilgeKitap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Entity
{
    public class BookCategory : IEntity
    {
        public int BookCategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual List<Book> Book { get; set; }
    }
}
