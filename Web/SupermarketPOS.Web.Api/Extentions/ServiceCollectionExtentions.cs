using Microsoft.OpenApi.Models;
using System.Runtime.CompilerServices;

namespace SupermarketPOS.Web.Api.Extentions
{
    public static class ServiceCollectionExtentions
    {
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
        public static IServiceCollection AddApplicationservices(this IServiceCollection services ,IConfiguration configuration,IWebHostEnvironment webHostBuilder)
        {
            AddOpenApiDocumentation(services);
            return services;
        }
    }
}

