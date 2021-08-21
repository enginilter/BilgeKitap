using BilgeKitap.Business.Abstract;
using BilgeKitap.Core.Aspects.Logging;
using BilgeKitap.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using BilgeKitap.Core.Utilities.Results;
using BilgeKitap.Data.Abstract;
using BilgeKitap.Entity;
using System.Collections.Generic;
using System.Linq;

namespace BilgeKitap.Business.Concrete
{
    public class BookCategoriesManager : IBookCategoryService
    {
        IBookCategoryDal _bookCategoryDal;

        public BookCategoriesManager(IBookCategoryDal bookCategoryDal)
        {
            _bookCategoryDal = bookCategoryDal;
        }

        public IResult Add(BookCategory bookCategories)
        {
            _bookCategoryDal.Add(bookCategories);
            return new SuccessResult();
        }

        public IResult Delete(BookCategory bookCategories)
        {
            _bookCategoryDal.Delete(bookCategories);
            return new SuccessResult();
        }


        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<BookCategory>> GetAll()
        {
            return new SuccessDataResult<List<BookCategory>>(_bookCategoryDal.GetAll().ToList());
        }

        public List<BookCategory> GetAllCategory()
        {
            return _bookCategoryDal.GetAll();
        }

        public IDataResult<BookCategory> GetByID(int bcategoryID)
        {

            return new SuccessDataResult<BookCategory>(_bookCategoryDal.Get(b => b.BookCategoryId == bcategoryID));
        }

        public IResult Update(BookCategory bookCategories)
        {
            _bookCategoryDal.Update(bookCategories);
            return new SuccessResult();
        }
    }
}
