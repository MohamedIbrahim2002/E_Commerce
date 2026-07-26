using E_Commerce.Application.Common;
using E_Commerce.Doamin.Entities.Products;

namespace E_Commerce.Application.Specification
{
    public class ProductCountSpecification : BaseSpecification<Product,int>
    {
        public ProductCountSpecification(ProductQueryParam queryParams) :
          base
            (
                  p =>
                  (!queryParams.BrandId.HasValue || p.BrandId == queryParams.BrandId)
                  &&
                  (!queryParams.TypeId.HasValue || p.TypeId == queryParams.TypeId)
                  &&
                 (string.IsNullOrWhiteSpace(queryParams.SeaechValue) || p.Name.ToLower().Contains(queryParams.SeaechValue.ToLower()))

            )

        {

        }



    }
}
