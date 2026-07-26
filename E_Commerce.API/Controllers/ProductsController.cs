using E_Commerce.API.Controllers.Attributes;
using E_Commerce.API.Services.Contracts;
using E_Commerce.Application.Common;
using E_Commerce.Application.DTOs.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductServices productServices) : APIBaseController
    {

        // Get :api/products
        
        [HttpGet]
        [RedisCache(60)]                                                  //FromQuery to bind Data from queryparam not form
        public async Task<ActionResult<PaginationResult<ProductDTO>>> GetAllProducts([FromQuery] ProductQueryParam queryParams , CancellationToken ct = default)

        {
            // check cache => in memory DB   (key , value)

            var result = await productServices.GetAllProductsAsync(queryParams);
            return ToActionResult(result);
        }
        // Get :api/products/brands
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<BrandDTO>>> GetAllPBrands(CancellationToken ct = default)
        {
            var result = await productServices.GetAllBrandsAsync(ct);
            return ToActionResult(result);
        }


        // Get :api/products/types
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<TypeDTO>>> GetAllTypes(CancellationToken ct = default)
        {
            var result = await productServices.GetAllTypesAsync(ct);
            return ToActionResult(result);
        }

        // Get :api/products/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id, CancellationToken ct = default)
        {
            var result = await productServices.GetProductByIdAsync(id, ct);

            return ToActionResult(result);
        }
            

    }
     
}
