using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OpenLab.Controllers.Base;
using OpenLab.Infrastructure.Interfaces.PresentationModels;
using OpenLab.Infrastructure.PresentationModels.Web;
using OpenLab.Models;
using OpenLab.Services.Filters;
using OpenLab.Services.Services;

namespace OpenLab.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IIdentityService identityService)
         : base(logger, httpContextAccessor, identityService) { }

        [CustomActionFilter(HttpContextAccessor, Order = 0)]
        public IActionResult Index()
        {
            UserInfoModel webUser = ViewBag.WebUser;

            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;
                TempData["SuccessMessage"] = null;
            }
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;
                TempData["ErrorMessage"] = null;
            }

            if (webUser.IsLogged)
            {
                ViewBag.User = JsonConvert.SerializeObject(webUser.User);
                ViewBag.Username = webUser.User.UserName;
            }

            ViewBag.IsLogged = webUser.IsLogged;
            ViewBag.IsAdminRole = webUser.IsAdmin;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
