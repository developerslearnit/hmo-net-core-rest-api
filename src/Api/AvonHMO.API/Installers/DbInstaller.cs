using AvonHMO.Persistence.StorageContexts.Avon;
using AvonHMO.Persistence.StorageContexts.Toshfa;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;

namespace AvonHMO.API.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AvonDbContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetSection("DBConnections:AvonConnection").Value,
                          sqlServerOptionsAction: sqlOptions =>
                          {
                              sqlOptions.EnableRetryOnFailure(
                                  maxRetryCount: 10,
                                  maxRetryDelay: TimeSpan.FromSeconds(30),
                                  errorNumbersToAdd: null
                                  );
                          }));

            builder.Services.AddDbContext<ToshfaDbContext>(options =>
                      options.UseSqlServer(builder.Configuration.GetSection("DBConnections:ToshfaConnection").Value,
                        sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.EnableRetryOnFailure(
                                maxRetryCount: 10,
                                maxRetryDelay: TimeSpan.FromSeconds(30),
                                errorNumbersToAdd: null
                                );
                        }));

            builder.Services.AddScoped<IDbConnection, SqlConnection>(db =>
                new SqlConnection(builder.Configuration.GetSection("DBConnections:ToshfaConnection").Value));
        }
    }
}
