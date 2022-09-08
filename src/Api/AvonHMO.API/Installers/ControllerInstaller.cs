using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AvonHMO.API.Installers
{
    public class ControllerInstaller : IInstaller
    {
        public void InstallServices(WebApplicationBuilder builder)
        {

            
            builder.Services.AddMemoryCache();

            builder.Services.AddControllers
                (config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();
        }
    }


}


