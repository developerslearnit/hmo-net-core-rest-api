using Microsoft.AspNetCore.Builder;

namespace AvonHMO.API.Installers
{
    public interface IInstaller
    {
        void InstallServices(WebApplicationBuilder builder);
    }
}
