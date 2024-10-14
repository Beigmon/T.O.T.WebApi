namespace TOT.Services.Caching.Interfaces
{
    public interface ICachingService
    {
        public Task<T?> GetAsync<T>(string key, CancellationToken token);

        public Task SetAsync(string key, object value, int durationInHours, CancellationToken token);
    }
}
