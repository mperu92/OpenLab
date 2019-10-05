using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenLab.Controllers.Base;
using OpenLab.DAL.EF.Models.Identity;
using OpenLab.Infrastructure.ViewModels;
using OpenLab.Services.Services;

namespace OpenLab.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(ILogger<AccountController> logger, IHttpContextAccessor httpContextAccessor, IIdentityService identityService, IEmailService emailSender)
           : base(logger, httpContextAccessor, identityService, emailSender) { }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(Uri ReturnUrl = null)
        {
            LoginViewModel model = new LoginViewModel();

            if (ReturnUrl != null)
                model.ReturnUrl = ReturnUrl;

            return View(model);
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid || model == null)
                return View(model);

            Microsoft.AspNetCore.Identity.SignInResult result = await IdentityService.Login(model).ConfigureAwait(false);

            if (result.Succeeded)
            {
                if (model.ReturnUrl != null)
                    return Redirect(model.ReturnUrl.ToString());
                else
                    return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Login Failed");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await IdentityService.LogOff().ConfigureAwait(false);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid || model == null)
                return View(model);

            IdentityUserModel user = new IdentityUserModel
            {
                UserName = model.UserName,
                Email = model.Email
            };

            bool debuggerSucceded = false;
            IdentityResult result = null;
            if (!System.Diagnostics.Debugger.IsAttached)
                result = await IdentityService.RegisterUser(user, model.Password).ConfigureAwait(false);
            else
                debuggerSucceded = true;

            if (result.Succeeded || debuggerSucceded)
            {
                int uId = result.Succeeded ? user.Id : 123;
                string confirmationCode = result.Succeeded ? await IdentityService.GenerateConfirmUserCode(user).ConfigureAwait(false) : "abcdefghi";
                string callbackUrl = Url.Action(controller: "Account", action: "ConfirmEmail", values: new { userId = user.Id, code = confirmationCode }, protocol: Request.Scheme);

                bool sent = await EmailService.SendWelcomeConfirmEmail(user.Email, "Confirm Email", new Uri(callbackUrl, UriKind.Absolute), user.UserName, model.Password).ConfigureAwait(false);
                
                if (sent)
                {
                    TempData["SuccessMessage"] = "Registration completed. Click on link above the email we sent you just now.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "Registration completed with erros. Email with confirmation code not sent.";
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
                return RedirectToAction("Index", "Home");

            IdentityUserModel user = await IdentityService.GetUserEntityById(userId).ConfigureAwait(false);
            if (user == null)
                throw new ApplicationException($"Unable to load user with Id '{userId}'.");

            IdentityResult result = await IdentityService.ConfirmEmailAsync(user, code).ConfigureAwait(false);
            if (result.Succeeded)
                return View("ConfirmEmail");

            TempData["ErrorMessage"] = "Email confirmation failed.";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}