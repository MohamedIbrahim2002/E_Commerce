using AutoMapper;
using E_Commerce.Application.DTOs.Product;
using E_Commerce.Doamin.Entities;
using E_Commerce.Doamin.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.MappingProfile.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductBrand,BrandDTO>();
            CreateMap<ProductType, TypeDTO>();
            CreateMap<Product, ProductDTO>()
                   .ForMember(D => D.ProductBrand, opt => opt.MapFrom(s => s.Brand.Name))
                   .ForMember(D => D.ProductType, opt => opt.MapFrom(s => s.Type.Name))
                   //.ForMember(D => D.PictureUrl, opt => opt.MapFrom(s => $" https://localhost:7136/{s.PictureUrl}"));
                   .ForMember(D => D.PictureUrl, opt => opt.MapFrom<PictureUrlResolver>());
        }
    }
}
