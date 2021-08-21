using BilgeKitap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Entity.DTOs
{
    public class BookDetailDto:IDto
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string CategoryName { get; set; }
        public string Authorname { get; set; }
        public int NumberOfPages { get; set; }
        public decimal Price { get; set; }
    }
}
