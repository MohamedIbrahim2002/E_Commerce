using E_Commerce.Doamin.Common;
using E_Commerce.Doamin.Contracts;
using E_Commerce.Doamin.Entities;
using E_Commerce.Doamin.Entities.Products;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Buffers.Text;
using System.Text.Json;


namespace E_Commerce.Infrastructure.DataSeeding
{
    // Primary Constructor Syntax Sugar
    public class CatalogDataSeeder(StoreDbContext context , ILogger<CatalogDataSeeder> logger) : IDataSeeder
    {
        public async Task SeedDataAsync(CancellationToken ct = default)
        {
            try
            {

                // Check database exist && Update
                var pendingMigrations = await context.Database.GetPendingMigrationsAsync(ct);
                if (pendingMigrations.Any())
                {
                    await context.Database.MigrateAsync();
                }

                // Get Path 
                var seedRootPath = Path.Combine(AppContext.BaseDirectory, "DataSeed");
                // Seeding

                // brand
                await SeedIfEmpty<ProductBrand, int>(seedRootPath, "brands.json", ct);
                // type ,
                await SeedIfEmpty<ProductType, int>(seedRootPath, "types.json", ct);
                // product
                await SeedIfEmpty<Product, int>(seedRootPath, "products.json", ct);
                
                var count = await context.SaveChangesAsync(ct);
                if (count > 0)

                    logger.LogInformation($" {count} Rows Added");
                else
                    logger.LogInformation("DB Already Seeded");



            }
            catch (Exception ex)
            {

                logger.LogError(ex.Message);
            }

        }

        private async Task SeedIfEmpty<TEntity , TKey>(string rootPath, string fileName, CancellationToken ct = default) 
            where TEntity :BaseEntity<TKey> 
        {
            
            if(await context.Set<TEntity>().AnyAsync())
            {
                var table = typeof(TEntity).Name;
                 logger.LogWarning($"Table {table} has  data");
                return;
            }
            var filePath = Path.Combine(rootPath, fileName);
            if (!File.Exists(filePath))
            {
                 logger.LogWarning($"file {fileName} not exist");
                return;
               
            }
            using var fileStream = File.OpenRead(filePath);
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            var data = await JsonSerializer.DeserializeAsync<List<TEntity>>(fileStream, options,ct);

            if(data is not null && data.Any())
                await context.Set<TEntity>().AddRangeAsync(data);

        }

    }
}
