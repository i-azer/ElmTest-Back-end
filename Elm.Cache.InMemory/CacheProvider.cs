using Elm.Application.Contracts.Services;
using Elm.Domain.Shared;
using Microsoft.Extensions.Caching.Memory;

namespace Elm.Cache.InMemory
{
    public class CacheProvider : ICacheProvider
    {
        private readonly IMemoryCache _memoryCache;
        public CacheProvider(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public void Add<TItem>(string key, TItem item, TimeSpan timeToLeft)
        {
            _memoryCache.Set($"{BookConst.CacheKeyPrefix}{key}", item, timeToLeft);
        }

        public TItem Get<TItem>(string key) where TItem : class
        {
            if (_memoryCache.TryGetValue($"{BookConst.CacheKeyPrefix}{key}", out TItem value))
            {
                return value;
            }

            return null;
        }
    }
}