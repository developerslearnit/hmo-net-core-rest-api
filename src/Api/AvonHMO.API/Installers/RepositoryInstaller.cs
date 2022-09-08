using AvonHMO.API.Helpers;
using AvonHMO.Domain.Interfaces;
using AvonHMO.Domain.Services;
using AvonHMO.Persistence.AuditUtils;
using BrightStar.Util.Storage.RepoManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AvonHMO.API.Installers
{
    public class RepositoryInstaller : IInstaller
    {
        public void InstallServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
            builder.Services.AddSingleton<IStorageRepoManager, StorageRepoManager>();
            builder.Services.AddScoped<IIPIntegratedSMS, IPIntegratedSMS>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddTransient<UserResolverService>();
        }
    }
}
