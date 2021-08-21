using BilgeKitap.Core.DataAccess.EntityFramework.Abstract;
using BilgeKitap.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Data.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
