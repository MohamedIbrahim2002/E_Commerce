using E_Commerce.Doamin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Doamin.Entities.Products
{
    public class Product:BaseEntity<int>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string PictureUrl { get; set; } = default!;
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public ProductBrand Brand { get; set; } = default!;
        public int TypeId { get; set; }
        public ProductType Type { get; set; } = default!;
    }
}
