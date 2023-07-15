using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Tests.Cache
{
        public interface ICache
        {
            public TryGetValue(string key, object value);
            bool Set(string key, object value, int minutesToCache);
            bool Remove(string key);
        bool TryGetValue(string cacheKey, out object cookies);
    }
    
}
