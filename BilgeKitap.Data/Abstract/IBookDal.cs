using BilgeKitap.Core;
using BilgeKitap.Core.DataAccess.EntityFramework.Abstract;
using BilgeKitap.Entity;
using BilgeKitap.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BilgeKitap.Data.Abstract
{
    public interface IBookDal:IEntityRepository<Book>
    {

        List<BookDetailDto> GetBookDetailDto(Expression<Func<BookDetailDto,bool>>filter=null);

    }
}
