using Microsoft.AspNetCore.Mvc;
using SupermarketPOS.Web.Api.Extentions;
using System.Runtime.CompilerServices;

namespace SupermarketPOS.Web.Api
{
    public static class DiContainer
    {
        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            var services = builder.Services;
            var enviroment= builder.Environment;
            var host = builder.Host;
            services.AddDatabase(configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("DefaultConnection string not found"));          
            services.AddControllers();
            services.RegisterServices(configuration,enviroment);
            services.AddOpenApiDocumentation();
            host.AddSerilog();  
            return builder;
        }
    }
}
