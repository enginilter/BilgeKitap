using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Core.Utilities.Security.Encryption
{
    //Şifrelenen kimliği oluşturuyoruz.
    public class SigninCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey security)
        {

            return new SigningCredentials(security, SecurityAlgorithms.HmacSha384Signature);
        }
    }
}
