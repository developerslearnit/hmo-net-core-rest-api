using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AvonHMO.API.Installers
{
    public class AzureBlobStorageInstaller : IInstaller
    {
        public void InstallServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton(x =>
            new BlobServiceClient(builder.Configuration.GetSection("Azure:AzureBlobStorageConnectionString").Value));
        }
    }
}
