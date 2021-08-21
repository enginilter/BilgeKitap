using BilgeKitap.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Core.Utilities.Security.JWT
{

    //Giriş yapan kullanıcının bilgileri eğer doğruysa,ilgili kullanıcı için veritabanına gidip claimlerini bulup JWT üretecek.
    //Kısacası ilgili kullanıcı için claimlerini içerecek bir token oluşturuyor.
   public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
