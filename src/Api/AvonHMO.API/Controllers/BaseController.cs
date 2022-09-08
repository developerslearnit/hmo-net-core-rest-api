using AvonHMO.API.Extensions;
using AvonHMO.API.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AvonHMO.API.Controllers
{

    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [APIKeyAuth]
    public class BaseController : ControllerBase
    {

        public string loggedInUserId { get { return HttpContext.LoggedInUserId(); } }

        public List<string> loggedInUserRoles { get { return HttpContext.LoggedInUserRoles(); } }

        public string memberNumber { get { return HttpContext.MemberNumber(); } }

        public string memberEmail { get { return HttpContext.MemberEmail(); } }
    }
}
