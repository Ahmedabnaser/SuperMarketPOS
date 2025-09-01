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
            services.AddControllers();
            services.AddApplicationservices(configuration,enviroment);
            //services.AddOpenApi();

            return builder;
        }
    }
}
