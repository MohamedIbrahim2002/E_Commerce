using E_Commerce.Application.Common;
using E_Commerce.Application.DTOs.Product;

namespace E_Commerce.API.Services.Contracts
{
    public interface IProductServices
    {
        Task<Result<PaginationResult<ProductDTO>>> GetAllProductsAsync(ProductQueryParam queryParams,CancellationToken ct = default); 
        Task<Result<ProductDTO?>> GetProductByIdAsync(int id,CancellationToken ct = default);
        Task<Result<IReadOnlyList<BrandDTO>>> GetAllBrandsAsync(CancellationToken ct = default);
        Task<Result<IReadOnlyList<TypeDTO>>> GetAllTypesAsync(CancellationToken ct = default);






    }
}
