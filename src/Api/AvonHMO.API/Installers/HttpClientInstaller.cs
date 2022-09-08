using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AvonHMO.API.Installers
{

    /// <summary>
    /// 
    /// </summary>
    public class HttpClientInstaller : IInstaller
    {
        public void InstallServices(WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient();
            
            builder.Services.AddHttpClient("toshfaClient", c =>
            {
                c.BaseAddress = new System.Uri(builder.Configuration.GetSection("ToshfaApiBaseUri").Value);
            });

            builder.Services.AddHttpClient("seerBitClient", c =>
            {
                c.BaseAddress = new System.Uri(builder.Configuration.GetSection("SeerBitApiBaseUri").Value);
            });

            builder.Services.AddHttpClient("SMSClient", c =>
            {
                c.BaseAddress = new System.Uri(builder.Configuration.GetSection("IPIntegratedSMSUri").Value);
            });
        }
    }
}
