using BilgeKitap.Core.DataAccess.EntityFramework.Concrete;
using BilgeKitap.Data.Abstract;
using BilgeKitap.Data.Concrete.EntityFramework;
using BilgeKitap.Entity;
using BilgeKitap.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BilgeKitap.Data.Concrete
{
    public class EFBookDal : EFEntityRepositoryBase<Book, BKContext>, IBookDal
    {

       
        public List<BookDetailDto> GetBookDetailDto(Expression<Func<BookDetailDto, bool>> filter = null)
        {
            using (BKContext db = new BKContext())
            {
                var result = from b in db.Books
                              join ct in db.BookCategories
                              on b.BookCategoryId equals ct.BookCategoryId
                              join a in db.Authors
                              on b.AuthorId equals a.AuthorId
                              select new BookDetailDto
                              {
                                  BookId = b.BookId,
                                  BookName = b.BookName,
                                  CategoryName = ct.CategoryName,
                                  Authorname = a.Firstname + a.Lastname,
                                  NumberOfPages = b.NumberOfPages,
                                  Price = b.Price
                              };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }

        }
    }
}
