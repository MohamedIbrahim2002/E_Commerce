using E_Commerce.Doamin.Contracts.Repositories;
using E_Commerce.Doamin.Entities.Baskets;
using StackExchange.Redis;
using System.Text.Json;

namespace E_Commerce.Infrastructure.Repositories
{
    public class BasketRepository(IConnectionMultiplexer connection) : IBasketRepository
    {
        private readonly IDatabase _database = connection.GetDatabase(); // in memory database
        public async Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? timeToLive = default, CancellationToken ct = default)
        {
            // serialize the basket object to a JSON string
            var value = JsonSerializer.Serialize(basket);

            var result = await _database.StringSetAsync(basket.Id, value, timeToLive?? TimeSpan.FromDays(7));

            return result ? basket : null;
        }

        public async Task<bool> DeleteBasketAsync(string basketId, CancellationToken ct = default)
        {
            return await _database.KeyDeleteAsync(basketId);

        }

        public async Task<CustomerBasket?> GetBasketAsync(string basketId, CancellationToken ct = default)
        {
            var value = await _database.StringGetAsync(basketId);
            var basket =  JsonSerializer.Deserialize<CustomerBasket>(value!);
            if(basket is null) return null;
            
            return  basket;
        }
        


    }
}
