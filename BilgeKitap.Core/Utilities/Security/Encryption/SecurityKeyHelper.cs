using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Core.Utilities.Security.Encryption
{
    //Oluşturulan şifreyi byte[] halini alıp Symetric anahtar haline getiriliyor.
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
