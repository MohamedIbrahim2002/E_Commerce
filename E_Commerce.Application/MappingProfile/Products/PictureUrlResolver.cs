using AutoMapper;
using E_Commerce.Application.DTOs.Product;
using E_Commerce.Doamin.Entities.Products;
using Microsoft.Extensions.Configuration;

namespace E_Commerce.Application.MappingProfile.Products
{
    public class PictureUrlResolver(IConfiguration configuration ) : IValueResolver<Product, ProductDTO, string>
    {
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {


            return $"/{configuration["BaseUrl"]}{source.PictureUrl}";
        }
    }
}
