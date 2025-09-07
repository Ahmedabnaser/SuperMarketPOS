using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using Serilog;
using SupermarketPOS.persistence.Data;
using System.Runtime.CompilerServices;

namespace SupermarketPOS.Web.Api.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services ,IConfiguration configuration,IWebHostEnvironment webHostBuilder)
        {
          
            return services;
        }



        public static IServiceCollection AddOpenApiDocumentation(this IServiceCollection services)
        {
            services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer((document, context, _) =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Title = "SuperMarketPos",
                        Description = """
                         Comprehensive API for SupermarketPos platform.
                         Supports JSON responses.
                         JWT authentication required for protected endpoints.
                        """,
                        Version = "V1",
                        Contact =new OpenApiContact
                        {
                            Name="SuperMarketPOS",
                            Email="SuperMarketPos@gmail.com"


                        }
                    };
                        return Task.CompletedTask;
                 
                });

            });
            return services;
        }
        public static void  ConfigScalar(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(
                    options =>
                    {
                        options.WithTitle("my Api")
                        .WithSidebar(true)
                        .WithDarkMode(true)
                        .WithDefaultOpenAllTags(true);

                    }

                    );
            }
        }
        public static IHostBuilder AddSerilog(this IHostBuilder builder)
        {
            builder.UseSerilog((context, configure) =>
            {
                configure.ReadFrom.Configuration(context.Configuration);
               var Connectionstring= context.Configuration.GetValue<string>("connectionString");
                Console.WriteLine(Connectionstring);
            });
            return builder;
        }
        public static IServiceCollection AddDatabase(this IServiceCollection services,string connectionstring)
        {
            if (string.IsNullOrEmpty(connectionstring))
            {
                throw new InvalidOperationException("Connection string 'ConnectionStrings' not found or is null/empty.");
            }
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionstring);
            });
            return services;

        }

    }
}

