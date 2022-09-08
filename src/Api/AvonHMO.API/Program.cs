
using AvonHMO.API.Extensions;
using AvonHMO.API.Installers;
using AvonHMO.API.Middlewares;
using AvonHMO.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.InstallServicesInAssembly();

builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("AvonHMOCorsPolicy");
app.UseForwardedHeaders(
    new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.All
    });


app.UseOwaspSecurityConfig();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
       name: "areas",
       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
     );
    endpoints.MapControllers();
});

app.Run();
