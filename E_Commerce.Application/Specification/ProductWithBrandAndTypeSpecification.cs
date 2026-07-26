using E_Commerce.Application.Common;
using E_Commerce.Doamin.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Specification
{
    public class ProductWithBrandAndTypeSpecification : BaseSpecification<Product,int> 
    {
        public ProductWithBrandAndTypeSpecification(ProductQueryParam queryParams) :
          base
            (
                  p=>
                  (!queryParams.BrandId.HasValue || p.BrandId == queryParams.BrandId)
                  &&
                  (!queryParams.TypeId.HasValue || p.TypeId== queryParams.TypeId) 
                  &&
                 (string.IsNullOrWhiteSpace(queryParams.SeaechValue)||p.Name.ToLower().Contains(queryParams.SeaechValue.ToLower()))
                  

            )      
        {
            
           AddInclude(p => p.Brand);
           AddInclude(p => p.Type);
            switch (queryParams.Sort)
            {
                 
                case ProductSortOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortOptions.NameDesc:
                    AddOrderByDescending(p => p.Name);
                    break;
                case ProductSortOptions.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortOptions.PriceDesc:
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Id);
                    break;
            }

            ApplyPagination(queryParams.PageIndex, queryParams.PageSize);
        }

        // get product by id && include related data
        public ProductWithBrandAndTypeSpecification(int id) : base(p=>p.Id==id)
        {

            AddInclude(p => p.Brand);
            AddInclude(p => p.Type);
        }
    }
}
