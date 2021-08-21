using BilgeKitap.Core.DataAccess.EntityFramework.Abstract;
using BilgeKitap.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Data.Abstract
{
    public interface IAuthorDal:IEntityRepository<Author>
    {
    }
}
