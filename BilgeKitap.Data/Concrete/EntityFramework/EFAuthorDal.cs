using BilgeKitap.Core.DataAccess.EntityFramework.Concrete;
using BilgeKitap.Data.Abstract;
using BilgeKitap.Data.Concrete.EntityFramework;
using BilgeKitap.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Data.Concrete
{
    public class EFAuthorDal:EFEntityRepositoryBase<Author, BKContext>,IAuthorDal
    {
    }

}
