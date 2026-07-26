using E_Commerce.Application.Services.Contracts;
using E_Commerce.Application.Services.Contracts.Basket;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController (IBasketServices basketServices): APIBaseController
    {

        //GET    /api/Baskets? id = { id }    # Get basket

        [HttpGet("{id}")]
        public async Task<ActionResult<BasketDto>> GetBasketAsync(string id, CancellationToken ct = default)
        {
            var result = await basketServices.GetBasketAsync(id, ct);
            return ToActionResult(result);
        }

        //POST      /api/Baskets      # Create/Update basket

        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateOrUpdateBasketAsync(BasketDto dto, CancellationToken ct = default)
        {
            var result = await basketServices.CreateOrUpdateBasketAsync(dto, ct: ct);
            return ToActionResult(result);
        }


        //DELETE /api/Baskets/{id}         # Delete basket    

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBasketAsync(string id, CancellationToken ct = default)
        {
            var result =await basketServices.DeleteBasketAsync(id, ct);
            return ToActionResult(result);
        }

    }
}
