using E_Commerce.API.Services.Contracts;
using E_Commerce.Application.Services.Classes;
using E_Commerce.Application.Services.Contracts;
using E_Commerce.Doamin.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection; 
namespace E_Commerce.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services) 
        {

            // to allow all mapping in  the assembly
            services.AddAutoMapper(c => { }, typeof(ApplicationServicesRegistration).Assembly);

            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IBasketServices, BasketService>();
            services.AddScoped<ICacheService, CacheServices>();


            return services;
        }






    }
}
