using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common
{
    public class ProductQueryParam
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string? SeaechValue { get; set; }
        public ProductSortOptions Sort { get; set; } = ProductSortOptions.None;
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

    }
    public enum ProductSortOptions
    { 
        None = 0,
        NameAsc = 1,
        NameDesc=2,
        PriceAsc=3, 
        PriceDesc =4
    }
}
