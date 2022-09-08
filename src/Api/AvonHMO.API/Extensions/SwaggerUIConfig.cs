using Microsoft.AspNetCore.Builder;

namespace AvonHMO.API.Extensions
{
    public static class SwaggerUIConfig
    {
        public static void UseSwaggerConfig(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AvonHMO API v1");
                c.RoutePrefix = "swagger";
            });
        }
    }
}

