using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Core.Utilities.Security.JWT
{

    //Buradaki sınıf Appsettings'teki bilgileri nesnel hale getirmek için kullanıldı.
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }

}
