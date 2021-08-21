using BilgeKitap.Core.DataAccess.EntityFramework.Concrete;
using BilgeKitap.Core.Entities.Concrete;
using BilgeKitap.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BilgeKitap.Data.Concrete.EntityFramework
{
    public class EFUserDal : EFEntityRepositoryBase<User, BKContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new BKContext())
            {
                var result = from operationclaim in context.OperationClaims
                             join useroperationclaim in context.UserOperationClaims
                                 on operationclaim.Id equals useroperationclaim.OperationClaimId
                             where useroperationclaim.UserId == user.Id
                             select new OperationClaim { Id = operationclaim.Id, Name = operationclaim.Name };
                return result.ToList();
            }
            return null;
        
        }
    }
}
