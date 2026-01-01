using Microsoft.Extensions.Caching.Memory;
using System;

namespace SkillIT_API.Extensions
{
    /// <summary>
    /// Extension methods for caching
    /// </summary>
    public static class CacheExtensions
    {
        /// <summary>
        /// Gets or creates a cached item
        /// </summary>
        public static TItem GetOrCreate<TItem>(this IMemoryCache cache, string key, Func<TItem> factory, int expirationMinutes = 30)
        {
            if (!cache.TryGetValue(key, out TItem cacheEntry))
            {
                cacheEntry = factory();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(expirationMinutes));

                cache.Set(key, cacheEntry, cacheEntryOptions);
            }

            return cacheEntry;
        }

        /// <summary>
        /// Removes a cached item
        /// </summary>
        public static void RemoveByPrefix(this IMemoryCache cache, string prefix)
        {
            // Note: IMemoryCache doesn't support prefix-based removal by default
            // This is a placeholder for a more sophisticated implementation
            // Consider using distributed cache (Redis) for production scenarios
        }
    }
}
