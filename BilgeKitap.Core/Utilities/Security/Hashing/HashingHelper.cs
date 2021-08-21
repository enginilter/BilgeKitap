using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Core.Utilities.Security.Hashing
{
    //Hash oluşturuluyor.
    public class HashingHelper
    {
        //Hash oluşturulurken hangi algoritma kullanılacak.
        public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            //Hangi Crpytograghy olacağını seçiyoruz.
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                //Gönderilen passwordun byte değeri alınıyor./Bir stringin byte karşılığını almak için kullanılan yöntem.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        //Hash doğrulama.
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
