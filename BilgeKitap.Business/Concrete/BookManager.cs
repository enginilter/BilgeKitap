using BilgeKitap.Business.Abstract;
using BilgeKitap.Business.BusinessAspects.Autofac;
using BilgeKitap.Business.Constants;
using BilgeKitap.Business.Validation_Rules.Fluent_Validation;
using BilgeKitap.Core.Aspects.Autofac.Validation;
using BilgeKitap.Core.Aspects.Logging;
using BilgeKitap.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using BilgeKitap.Core.Utilities.Business;
using BilgeKitap.Core.Utilities.Results;
using BilgeKitap.Data.Abstract;
using BilgeKitap.Entity;
using BilgeKitap.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BilgeKitap.Business.Concrete
{
   

    public class BookManager : IBookService
    {
        IBookDal _bookDal;
        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        #region Crud
        public IResult Add(Book book)
        {
            _bookDal.Add(book);
            return new SuccessResult(Messages.BookAdded);

        }

        public IResult Delete(Book book)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Book book)
        {
            throw new NotImplementedException();
        } 
        #endregion



        public IDataResult<List<Book>> GetAll()
        {
            if (DateTime.Now.Hour == 01)
            {
                return new ErrorDataResult<List<Book>>(Messages.ZamanAsimi);
            }

            return new SuccessDataResult<List<Book>>(_bookDal.GetAll().ToList(), Messages.BookListed);
        }

      

        public IDataResult<Book> GetById(int bookId)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(b => b.BookId == bookId));
        }

        public IDataResult<List<Book>> GetListCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(p => p.BookCategoryId == categoryId).ToList());
        }

        public IDataResult<List<BookDetailDto>> GetBookDetailDto()
        {
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetailDto());
        }

        public IDataResult<List<BookDetailDto>> GetBookByID(int bookId)
        {
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetailDto(b=>b.BookId==bookId));
        }





        #region BusinessRules
        private IResult CheckBookName(string bookName)
        {
            var result = _bookDal.GetAll(b => b.BookName == bookName).Any();
            if (result)
            {
                return new ErrorResult(Messages.BookListed);
            }
            return new SuccessResult();
        }

       
        #endregion
    }
}
