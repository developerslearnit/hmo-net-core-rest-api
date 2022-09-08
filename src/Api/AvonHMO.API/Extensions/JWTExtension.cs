using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AvonHMO.API.Extensions
{
    public static class JWTExtension
    {

        public static string LoggedInUserId(this HttpContext httpContext)
        {
            if (httpContext == null) return string.Empty;


            return httpContext.User.Claims.Where(x => x.Type == ClaimTypes.GroupSid).Select(x=>x.Value).FirstOrDefault();
        }

        public static string LoggedInUserName(this HttpContext httpContext)
        {
            if (httpContext == null) return string.Empty;


            return httpContext.User.Claims.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value).FirstOrDefault();
        }


        public static List<string> LoggedInUserRoles(this HttpContext httpContext)
        {
            if (httpContext == null) return new List<string>();

            return httpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role)
                .Select(x => x.Value).ToList();
        }

        public static string MemberNumber(this HttpContext httpContext)
        {
            if (httpContext == null) return string.Empty;


            return httpContext.User.Claims.Where(x => x.Type == ClaimTypes.GivenName).Select(x => x.Value).FirstOrDefault();
        }

        public static string MemberEmail(this HttpContext httpContext)
        {
            if (httpContext == null) return string.Empty;


            return httpContext.User.Claims.Where(x => x.Type == ClaimTypes.Email).Select(x => x.Value).FirstOrDefault();
        }
    }
}
