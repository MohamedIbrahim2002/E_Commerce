using E_Commerce.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace E_Commerce.API.Controllers.Attributes
{
    public class RedisCacheAttribute (int timeInSec): ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // get cache  from DI
            var cacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();

            // check if cache exist 
            var cacheKey = CreateCacheKey(context.HttpContext.Request);
            var cachedData = await cacheService.GetAsync(cacheKey);

            if (string.IsNullOrEmpty(cachedData))
            {
                // return response from cached data
                context.Result = new ContentResult()
                {
                    Content = cachedData,
                    StatusCode = 200,
                    ContentType = "application/json"
                };
            }
            else
            {
                //call & execute Api method   and cache the result 
                var executed = await next.Invoke();
                if (executed.Result is OkObjectResult okResult)
                {
                    await cacheService.SetAsync(cacheKey, okResult.Value, TimeSpan.FromSeconds(timeInSec));
                }

            }

            // if cache exist => return cache Data

            // if not exist => execute the action and cache the result



            return;
        }

        private static string CreateCacheKey(HttpRequest request)
        {
            var Key = new StringBuilder();
            Key.Append(request.Path);
            foreach (var item in request.Query)
            {
                Key.Append($"{item.Key} | {item.Value}");
            }
            return Key.ToString();
        }
    }
}
