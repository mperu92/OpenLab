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
using OpenLab.Models;
using OpenLab.Services.Services;

namespace OpenLab.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IIdentityService identityService)
         : base(logger, httpContextAccessor, identityService) { }

        public async Task<IActionResult> Index()
        {
            //IUserModel[] users = await IdentityService.GetUsers().ConfigureAwait(false);
            //ViewBag.Users = users;

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
            //return View();
            bool isLogged = false;
            bool isAdminRole = false;

            if (HttpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                isLogged = true;

                if (HttpContextAccessor.HttpContext.User.IsInRole("Admin"))
                    isAdminRole = true;

                IUserModel user = await IdentityService.GetUserAsync(HttpContextAccessor.HttpContext.User).ConfigureAwait(false);

                // not generating error
                if (user == null || user.Id <= 0)
                {
                    user.Id = 00;
                    user.UserName = "noname";
                }
                // string userJson = JsonConvert.SerializeObject(user);

                ViewBag.User = JsonConvert.SerializeObject(user);
                ViewBag.Username = HttpContextAccessor.HttpContext.User.Identity.Name;
            }

            ViewBag.IsLogged = isLogged;
            ViewBag.IsAdminRole = isAdminRole;
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
