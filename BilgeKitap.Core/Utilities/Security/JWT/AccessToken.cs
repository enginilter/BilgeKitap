using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        //Giriş Bileti
        public string Token { get; set; }

        //Bitiş Zamanı.
        public DateTime Expiration { get; set; }
    }
}
