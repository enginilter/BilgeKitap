using BilgeKitap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Entity
{
   public class Book : IEntity
    {
        public int BookId { get; set; }

        public string BookName { get; set; }
        public int NumberOfPages { get; set; }
        public decimal Price { get; set; }
        public string BookImage { get; set; }
        public bool OnlineSales { get; set; }

        public int BookCategoryId { get; set; }
        public virtual BookCategory BookCategories { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }


    }
}
