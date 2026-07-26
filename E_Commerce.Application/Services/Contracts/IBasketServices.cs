using E_Commerce.Application.Common;
using E_Commerce.Application.Services.Contracts.Basket;
using E_Commerce.Doamin.Entities.Baskets;

namespace E_Commerce.Application.Services.Contracts
{
    public interface IBasketServices 
    {

        // get basket by id => basketId => basketDto
        Task<Result<BasketDto?>> GetBasketAsync(string basketId, CancellationToken ct = default);
        // create or update basket => basketDto => basketDto
        Task<Result<BasketDto?>?> CreateOrUpdateBasketAsync(BasketDto dto, TimeSpan? timeToLive = default, CancellationToken ct = default);
        // delete basket by id => basketId => bool
        Task<Result<bool>> DeleteBasketAsync(string basketId, CancellationToken ct = default);
    }
}
