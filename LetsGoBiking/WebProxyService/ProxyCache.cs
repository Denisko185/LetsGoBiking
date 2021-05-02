using System;
using System.Runtime.Caching;

namespace WebProxyService
{
    class ProxyCache<T> where T : class, new()
    {
       private ObjectCache cache;
       private DateTimeOffset dt_default;

        public ProxyCache()
        {
            cache = MemoryCache.Default;
            dt_default = ObjectCache.InfiniteAbsoluteExpiration;
        }

        //(T) Activator.CreateInstance(typeof(T), tonParam)
        public T Get(string CacheItem)
        {
            if (cache.Get(CacheItem) == null)
                cache.Add(CacheItem, (T)Activator.CreateInstance(typeof(T), CacheItem), null);
            return (T)cache.Get(CacheItem);
        }

        public T Get(string CacheItem, double dt_seconds)
        {
            var cacheItemPolicy1 = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(dt_seconds),

            };
            T cont = null;
            if (cache.Get(CacheItem) == null)
            {
                cont = (T)Activator.CreateInstance(typeof(T), CacheItem);
                cache.Add(CacheItem, cont, cacheItemPolicy1);
            }
            return (T)cache.Get(CacheItem);
            //return cont;
        }

        public T Get(string CacheItem, DateTimeOffset dt)
        {
            var cacheItemPolicy1 = new CacheItemPolicy
            {
                AbsoluteExpiration = dt,

            };
            if (cache.Get(CacheItem) == null)
                cache.Add(CacheItem, (T)Activator.CreateInstance(typeof(T), CacheItem), cacheItemPolicy1);
            return (T)cache.Get(CacheItem);
        }

    }
}
