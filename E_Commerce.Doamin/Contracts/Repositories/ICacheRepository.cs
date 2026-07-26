

namespace E_Commerce.Doamin.Contracts.Repositories
{
    public interface ICacheRepository
    { 
        Task<string?> GetAsync(string key, CancellationToken ct = default);
        Task SetAsync (string key, object value, TimeSpan? duration = default, CancellationToken ct = default);
    
    }
}
