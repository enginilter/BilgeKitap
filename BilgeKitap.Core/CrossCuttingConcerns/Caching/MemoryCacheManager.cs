using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Core.CrossCuttingConcerns.Caching
{
    public class MemoryCacheManager : ICacheManager
    {
        public void Add(string key, object value, int duration)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public bool IsAdd(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveByPattern(string pattern)
        {
            throw new NotImplementedException();
        }
    }
}
