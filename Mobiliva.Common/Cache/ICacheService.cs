using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mobiliva.Common.Cache
{
    public interface ICacheService
    {
        T Get<T>(string key, Func<T> getItemCallback, int cacheTime = 100) where T : class;
        Task<T> GetAsync<T>(string key, Func<Task<T>> getItemCallback, int cacheTime = 100) where T : class;

        bool Contains(string key);
        void Set(string key, object data, int cacheTime);
        void Invalidate(string key);
        void Invalidate(Regex pattern);
        void Clear();
        bool IsSet(string key);
    }
}
