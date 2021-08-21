using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Core.CrossCuttingConcerns.Caching
{
   public interface ICacheManager
    {
        T Get<T>(string key);
        //Duration:Cache'de ne kadar duracak.isteğe göre dakika veya saat cinsiniden ayarlanabilir.
        void Add(string key, object value, int duration);

        //Cache de varmı;
        bool IsAdd(string key);

        void Remove(string key);

        //Parametreli metotlar için(İsminde get,category vs. geçenleri bul);
        void RemoveByPattern(string pattern);
    }
}
