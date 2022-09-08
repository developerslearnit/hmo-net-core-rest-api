using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AvonHMO.API.Installers
{
    public class CorsInstaller : IInstaller
    {
        public void InstallServices(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AvonHMOCorsPolicy", builder =>

                  builder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader());
            });
        }
    }
}
