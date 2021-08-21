 using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BilgeKitap.Core.Extensions
{
    /// <ExtensionMetod>
    /// 
    /// Kullanmak istediğimiz nesne için metotlarını genişletilebilir yapmak.
    /// Claim nesnesinin metotlarında bulunmayan AddEmail,AddName gibi metotlar eklendi.
    /// 
    /// Nasıl Kullanılır?
    /// -----------------
    /// Public static bir class oluşturulur.
    /// Oluşturmak istediğimiz method da static olarak tanımlanmalıdır. 
    ///*** Methodu oluştururken hangi tip üzerinde bu metodun çalışmasını sağlayacağımızı this keyword’ü ile belirlemeliyiz.

    /// </ExtensionMetod>
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }

    }
}
