using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            IUserModel[] users = await IdentityService.GetUsers().ConfigureAwait(false);
            ViewBag.Users = users;

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
