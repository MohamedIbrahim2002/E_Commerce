using AutoMapper;
using E_Commerce.Application.Common;
using E_Commerce.Application.Services.Contracts;
using E_Commerce.Application.Services.Contracts.Basket;
using E_Commerce.Doamin.Contracts.Repositories;
using E_Commerce.Doamin.Entities.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Services.Classes
{
    public class BasketService (IBasketRepository basketRepository , IMapper mapper): IBasketServices
    {
        public async Task<Result<BasketDto?>> CreateOrUpdateBasketAsync(BasketDto dto, TimeSpan? timeToLive = null, CancellationToken ct = default)
        {
             var basketDto = mapper.Map<CustomerBasket>(dto);
             var result =await basketRepository.CreateOrUpdateBasketAsync(basketDto, timeToLive, ct);
            if(result is null) 
                return Result<BasketDto?>.Fail(Error.Failure("Basket not found", "Basket not found"));
             
            return Result<BasketDto?>.OK(dto);
        }

        public async Task<Result<bool>> DeleteBasketAsync(string basketId, CancellationToken ct = default)
        {
            var basket = await basketRepository.GetBasketAsync(basketId, ct);
            if (basket is null)
                return Result<bool>.Fail(Error.NotFound("Basket not found", $"basket with ID {basketId} not found"));
            
            var result = await basketRepository.DeleteBasketAsync(basketId, ct);
            return result ? Result<bool>.OK(result) : Result<bool>.Fail(Error.Failure("Basket not found", "Cannot delete basket"));
        }

        public async Task<Result<BasketDto>> GetBasketAsync(string basketId, CancellationToken ct = default)
        {
            var basket = await basketRepository.GetBasketAsync(basketId, ct);
            if (basket is null)
                return Result<BasketDto>.Fail(Error.NotFound("Basket not found", $"basket with ID {basketId} not found"));
            var dto = mapper.Map<BasketDto>(basket);    
            return Result<BasketDto>.OK(dto);


        }
    }
}   

