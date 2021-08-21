using BilgeKitap.Core.DataAccess.EntityFramework.Concrete;
using BilgeKitap.Data.Abstract;
using BilgeKitap.Data.Concrete.EntityFramework;
using BilgeKitap.Entity;
using BilgeKitap.Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BilgeKitap.Data.Concrete
{
    public class EFBookCategoriesDal : EFEntityRepositoryBase<BookCategory, BKContext>, IBookCategoryDal
    {
        //public List<CategoryDetailDto> GetCategoryDetailDtos()
        //{
        //    using (BKContext context = new BKContext())
        //    {
        //        var result = from b in context.Books
        //                     join c in context.BookCategories
        //                     on b.BookCategoryId equals c.BookCategoryId
        //                     select new CategoryDetailDto
        //                     {
        //                         BookId = b.BookId,
        //                         CategoryId = c.BookCategoryId,
        //                         CategoryName = c.CategoryName,
        //                         BookQuantity = context.Books.Count()
        //                   }

        //    }

        //}

    }
}

