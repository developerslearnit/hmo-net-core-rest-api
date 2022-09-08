using AvonHMO.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AvonHMO.API.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class APIKeyAuthAttribute : Attribute, IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<APIKeyAuthAttribute>>();

            var AvonHeaderKey = "YWRtaW46UEAkJHcwcmQxMjMkI0A=";


            if (!context.HttpContext.Request.Headers.TryGetValue(AppConstants.APIKEY_KEY_NAME, out var potentialApiKey))
            {
                var errorMessage = $"{AppConstants.APIKEY_KEY_NAME} is missing in the request header";

                _logger.LogError(errorMessage);

                context.Result = new UnauthorizedResult();

                return;
            }

            if (!potentialApiKey.Equals(AvonHeaderKey)){
                var errorMessage = $"Wrong {AppConstants.APIKEY_KEY_NAME}";

                _logger.LogError(errorMessage);

                context.Result = new UnauthorizedResult();

                return;
            }


            await next();
        }

    }
}
