
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
        public static void Main(string[] args)
        {
            Log.Information("Starting SupermarketPOS Web API");
            try
            {
                var builder = WebApplication.CreateBuilder(args);
               
                // Add services to the container.

                builder.AddServices();
                
                var app = builder.Build();

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
