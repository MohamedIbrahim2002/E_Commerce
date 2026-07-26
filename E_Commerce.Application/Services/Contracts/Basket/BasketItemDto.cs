using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Services.Contracts.Basket
{
    public class BasketItemDto
    {
        [Required (ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "ProductName is required")]
        public string ProductName { get; set; } = default!;
        public string PicturUrl { get; set; } = default!;

        [Range  (1, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        [Range (1, int.MaxValue, ErrorMessage = "Quantity must be a positive value")]
        public int Quantity { get; set; }
    }
}
