using E_Commerce.Doamin.Contracts;

namespace E_Commerce.API.Extentions
{
    public static class WebAppExtentions
    {
        public static async Task<WebApplication> SeedAndMigrateAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dataSeeder = scope.ServiceProvider.GetRequiredKeyedService<IDataSeeder>("Catalog");
            var IdentitydataSeeder = scope.ServiceProvider.GetRequiredKeyedService<IDataSeeder>("Identity");

            await dataSeeder.SeedDataAsync();
            await IdentitydataSeeder.SeedDataAsync();

            return app;



        }
    }
}
