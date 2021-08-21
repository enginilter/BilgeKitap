using BilgeKitap.Core.Utilities.Results;
using BilgeKitap.Entity;
using BilgeKitap.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BilgeKitap.Business.Abstract
{
    public interface IBookService
    {
        IDataResult<List<Book>> GetAll();
        IDataResult<List<Book>> GetListCategoryId(int categoryId);
        IResult Add(Book book);
        IResult Delete(Book book);
        IResult Update(Book book);
        IDataResult<Book> GetById(int bookId);
    
        IDataResult<List<BookDetailDto>> GetBookDetailDto();
        IDataResult<List<BookDetailDto>> GetBookByID(int bookId);
    }
}
