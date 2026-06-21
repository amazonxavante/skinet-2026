using System.Text.Json;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Services;

public class ResponseCacheService(IConnectionMultiplexer redis) : IResponseCacheService
{
    private readonly IDatabase _database = redis.GetDatabase(1);

    public async Task CacheResponseAsyncy(string cacheKey, object response, TimeSpan timeToLive)
    {
        

        var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

        var serializedResponse = JsonSerializer.Serialize(response, options);
        await _database.StringSetAsync(cacheKey,serializedResponse, timeToLive);

        
    }

    public async Task<string?> GetCacheResponseAsync(string cachekey)
    {
         var cachedResponse = await _database.StringGetAsync(cachekey);

        if (cachedResponse.IsNullOrEmpty) return null;

        return cachedResponse;
    }

    public async  Task RemoveCacheByPattern(string pattern)
    {
        var server = redis.GetServer(redis.GetEndPoints().First());
        var Keys = server.Keys(database: 1, pattern: $"*{pattern}*").ToArray();
         if (Keys.Length != 0)
        {
            await _database.KeyDeleteAsync(Keys);
        }
    }



}