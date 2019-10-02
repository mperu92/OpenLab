using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenLab.Areas.Base;
using OpenLab.Services.Services;

namespace OpenLab.Areas.Backoffice.Controllers
{
    [Authorize(Roles = "Admin, PowerUser")]
    public class DashboardController : BaseController
    {
        public DashboardController(ILogger<DashboardController> logger, IHttpContextAccessor httpContextAccessor, IIdentityService identityService, IBackofficeService backofficeService)
            : base(logger, httpContextAccessor, identityService, null, backofficeService) { }

        public IActionResult Index()
        {
            ViewBag.Username = _httpContextAccessor.HttpContext.User.Identity.Name;

            return View();
        }
    }
}