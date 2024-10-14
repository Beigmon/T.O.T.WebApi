using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using TOT.Services.Caching.Interfaces;

namespace TOT.Services.Caching
{
    public class CachingService(IDistributedCache distributedCache) : ICachingService
    {
        public async Task<T?> GetAsync<T>(string key, CancellationToken token)
        {
            try
            {
                var content = await distributedCache.GetStringAsync(key, token);
                return string.IsNullOrWhiteSpace(content)
                    ? default
                    : JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception)
            {
                return default;
            }
        }

        public async Task SetAsync(string key, object value, int durationInHours, CancellationToken token)
        {
            try
            {
                var content = JsonConvert.SerializeObject(value);
                var options = new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(durationInHours)
                };

                await distributedCache.SetStringAsync(key, content, options, token);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
