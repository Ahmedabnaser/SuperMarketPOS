
using Scalar.AspNetCore;
using SupermarketPOS.Web.Api;
using SupermarketPOS.Web.Api.Extentions;
using Serilog;
using SupermarketPOS.persistence.Data;
using Microsoft.EntityFrameworkCore;
namespace OnionArch
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Information("Starting SupermarketPOS Web API");
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.
                builder.AddServices();

                var app = builder.Build();

                // Apply migrations and run seeders in a scope
                using (var scope = app.Services.CreateScope())
                {
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

                // Configure the HTTP request pipeline.
                app.ConfigScalar();

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.UseSerilogRequestLogging();
                app.MapControllers();

                app.Run();
            }
            catch (Exception ex) {
                Log.Fatal(ex, "Application terminated unexpectedly");
                throw;
            }
            finally
            {
                Log.Information("Shutting down SupermarketPOS Web API");
                Log.CloseAndFlush();
            }
        }
    }
}
