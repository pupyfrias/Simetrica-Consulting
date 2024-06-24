using Microsoft.Extensions.Caching.Memory;

namespace SimetricaConsulting.Application.Extensions
{
    public static class CacheExtension
    {
        public static void InvalidateCache<TEntity>(this IMemoryCache cache)
        {
            string cacheKey = $"{typeof(TEntity).FullName}Cache";
            cache.Remove(cacheKey);
        }
    }
}