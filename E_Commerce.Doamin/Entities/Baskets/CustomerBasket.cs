using E_Commerce.Doamin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Doamin.Entities.Baskets
{
    public class CustomerBasket 
    {
        public  string Id { get; set; } // Guid
        public ICollection<Baskettem> Items { get; set; } = [];

    }
}
