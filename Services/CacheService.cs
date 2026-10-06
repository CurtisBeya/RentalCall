using Microsoft.Extensions.Caching.Memory;
using RentalCall.Services.Interfaces;

namespace RentalCall.Services
{
    public class CacheService: ICacheService
    {
        private readonly IMemoryCache _cache;
        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        //adds an item to the cache with a specified key and value, and sets the cache expiration to 1 day
        public void Set<T>(string key, T value)
        {
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
            };

            _cache.Set(key, value, options);
        }

        //retrieves an item from the cache based on the specified key. If the item is found, it returns the value;
        //otherwise, it returns the default value for the type T.
        public T? Get<T>(string key)
        {
            return _cache.TryGetValue(key, out T value) ? value : default;
        }

        //removes an item from the cache based on the specified key.
        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
