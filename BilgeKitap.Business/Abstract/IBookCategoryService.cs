using BilgeKitap.Core.Utilities.Results;
using BilgeKitap.Entity;
using System.Collections.Generic;

namespace BilgeKitap.Business.Abstract
{
    public interface IBookCategoryService
    {
        IDataResult<List<BookCategory>> GetAll();
        IResult Add(BookCategory bookCategories);
        IResult Delete(BookCategory aubookCategoriesthor);
        IResult Update(BookCategory bookCategories);
        IDataResult<BookCategory> GetByID(int bcategoryID);
        List<BookCategory> GetAllCategory();
    }
}
