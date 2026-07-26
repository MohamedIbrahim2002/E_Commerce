using AutoMapper;
using E_Commerce.Application.Services.Contracts.Basket;
using E_Commerce.Doamin.Entities.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.MappingProfile.Baskets
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<CustomerBasket, BasketDto>().ReverseMap();

            CreateMap<Baskettem, BasketItemDto>().ReverseMap();
        }
    }
}
