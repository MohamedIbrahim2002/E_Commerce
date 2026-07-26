using E_Commerce.Doamin.Contracts;
using E_Commerce.Doamin.Entities.Identity;
using E_Commerce.Infrastructure.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; 

namespace E_Commerce.Infrastructure.DataSeeding
{
    public class IdentityDataSeeder(
        StoreIdentityDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ILogger<IdentityDataSeeder> logger
        ) : IDataSeeder

    {
        public async Task SeedDataAsync(CancellationToken ct = default)
        {

            try
            {
                // check if the database is Exist & empty & Updated

                var pendingMigrations = await context.Database.GetPendingMigrationsAsync(ct);
                if (pendingMigrations.Any())
                {
                    await context.Database.MigrateAsync();
                }

                // Seed Roles

                if (!await roleManager.Roles.AnyAsync())
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                    await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));

                }


                // Seed Users
                if (!await userManager.Users.AnyAsync())
                {
                    var admin = new ApplicationUser
                    {
                        UserName = "admin",
                        Email = "admin@example.com",
                        DisplayName = "Admin User",
                        PhoneNumber = "1234567890"

                    };
                    var result = await userManager.CreateAsync(admin, "P@ssw0rd");
                    if (result.Succeeded)
                    {
                        // Handle successful user creation

                        await userManager.AddToRoleAsync(admin, "Admin");
                    }
                    else
                    {
                        var errors = result.Errors.Select(e => e.Description);
                        logger.LogWarning($"Failed to create admin user: {string.Join(", ", errors)}");
                    }
                
                };


            }
            catch (Exception ex)
            {

                logger.LogError(ex.Message);
            }


        }
    } 
}
