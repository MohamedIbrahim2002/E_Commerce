using AutoMapper;
using E_Commerce.API.Services.Contracts;
using E_Commerce.Application.Common;
using E_Commerce.Application.DTOs.Product;
using E_Commerce.Application.Specification;
using E_Commerce.Doamin.Contracts;
using E_Commerce.Doamin.Entities;
using E_Commerce.Doamin.Entities.Products;

namespace E_Commerce.Application.Services.Classes
{
    public class ProductServices(IUnitOfWork unitOfWork ,IMapper mapper) : IProductServices
    {
        public async Task<Result<IReadOnlyList<BrandDTO>>> GetAllBrandsAsync(CancellationToken ct = default)
        {
           var brands = await unitOfWork.GetRepository<ProductBrand,int>().GetAllAsync(ct);
            // mapping brand from DB to DTO
            var brandDTO = mapper.Map<IReadOnlyList<BrandDTO>>(brands);

            return Result<IReadOnlyList<BrandDTO>>.OK(brandDTO);
        }

        public async Task<Result<PaginationResult<ProductDTO>>> GetAllProductsAsync(ProductQueryParam queryParams, CancellationToken ct = default)
        {
            var specs = new ProductWithBrandAndTypeSpecification(queryParams);

            var products = await unitOfWork.GetRepository<Product,int>().GetAllAsync(specs,ct);

            var productDTOs = mapper.Map<IReadOnlyList<ProductDTO>>(products);

            var countSpecs = new ProductCountSpecification(queryParams);

            var count =await  unitOfWork.GetRepository<Product,int>().CountAsync(countSpecs,ct);

            var value = new PaginationResult<ProductDTO>(queryParams.PageIndex,queryParams.PageSize,count,productDTOs);
            return Result< PaginationResult < ProductDTO>>.OK(value);
        }

        public async Task<Result<IReadOnlyList<TypeDTO>>> GetAllTypesAsync(CancellationToken ct = default)
        {

            var types = await unitOfWork.GetRepository<ProductType, int>().GetAllAsync(ct);

            var typeDTOs = mapper.Map<IReadOnlyList<TypeDTO>>(types);

            return Result<IReadOnlyList<TypeDTO>>.OK(typeDTOs);
        }

        public async Task<Result<ProductDTO?>> GetProductByIdAsync(int id, CancellationToken ct = default)
        {
            var specs = new ProductWithBrandAndTypeSpecification(id);
            var product = await unitOfWork.GetRepository<Product,int>().GetByIdAsync(specs, ct);
            if (product == null)
                return Result<ProductDTO>.Fail(Error.NotFound("Product.NotFound", $"Product with {id} NotFound"));

            var productDTOs = mapper.Map<ProductDTO>(product);
            return Result<ProductDTO>.OK(productDTOs);
        }



    }
}
