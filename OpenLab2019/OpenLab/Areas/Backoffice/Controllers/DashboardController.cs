using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OpenLab.Areas.Base;
using OpenLab.Infrastructure.Interfaces.PresentationModels;
using OpenLab.Services.Services;

namespace OpenLab.Areas.Backoffice.Controllers
{
    [Authorize(Roles = "Admin, PowerUser")]
    public class DashboardController : BaseController
    {
        public DashboardController(ILogger<DashboardController> logger, IHttpContextAccessor httpContextAccessor, IIdentityService identityService, IBackofficeService backofficeService)
            : base(logger, httpContextAccessor, identityService, null, backofficeService) { }

        public async Task<IActionResult> Index()
        {
            bool isLogged = false;
            bool isAdminRole = false;
            ViewBag.Username = HttpContextAccessor.HttpContext.User.Identity.Name;

            if (HttpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                isLogged = true;
                if (HttpContextAccessor.HttpContext.User.IsInRole("Admin"))
                    isAdminRole = true;

                IUserModel user = await IdentityService.GetUserAsync(HttpContextAccessor.HttpContext.User).ConfigureAwait(false);

                // not generating error
                if (user == null || (user != null && user.Id <= 0))
                {
                    user.Id = 00;
                    user.UserName = "noname";
                }
                string userJson = JsonConvert.SerializeObject(user);

                ViewBag.User = userJson;
                ViewBag.IsLogged = isLogged;
                ViewBag.IsAdminRole = isAdminRole;

                return View();
            }

            TempData["ErrorMessage"] = "You have to must be logged to navigate on backoffice";
            return RedirectToAction("Index", "Home");
        }
    }
}