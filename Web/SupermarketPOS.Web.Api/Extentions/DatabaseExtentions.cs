using Microsoft.EntityFrameworkCore;
using OnionArch;
using SupermarketPOS.persistence.Data;

namespace SupermarketPOS.Web.Api.Extentions
{
    public static class DatabaseExtentions
    {
        public static async Task SeedingAdmingAndRoles(this WebApplication app)
        {
                using var scope = app.Services.CreateScope();
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                try
                {
                var db = services.GetRequiredService<ApplicationDbContext>();
                    logger.LogInformation("Applying pending migrations (if any)");
                    await db.Database.MigrateAsync();

                    var seeder = services.GetRequiredService<IdentityDataSeeder>();
                    await seeder.SeedRolseAndAdminsAsync(services);
                    //await seeder.SeedStaff();
                    logger.LogInformation("Database seeding completed.");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while migrating or seeding the database.");
                    throw;
                }
        }

    }
}

