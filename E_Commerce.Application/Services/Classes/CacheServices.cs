using E_Commerce.Application.Services.Contracts;
using E_Commerce.Doamin.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Services.Classes
{
    public class CacheServices(ICacheRepository _cacheRepository) : ICacheService
    { 

        public async Task<string?> GetAsync(string key, CancellationToken ct = default)
        {
            return await _cacheRepository.GetAsync(key, ct);
        }

        public async Task SetAsync(string key, object value, TimeSpan? timeToLive = null, CancellationToken ct = default)
        {
            await _cacheRepository.SetAsync(key, value, timeToLive ?? TimeSpan.FromMinutes(1), ct);
        }

    }
}
