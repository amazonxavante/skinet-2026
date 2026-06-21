namespace Core.Interfaces;

public interface IResponseCacheService
{
    
    Task CacheResponseAsyncy(string cacheKey, object response, TimeSpan timeToLive);
    Task<string?> GetCacheResponseAsync(string cachekey);
    Task RemoveCacheByPattern(string pattern);


}