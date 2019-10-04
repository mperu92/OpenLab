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
        public IActionResult Login(string ReturnUrl = null)
        {
            LoginViewModel model = new LoginViewModel();

            if (!string.IsNullOrEmpty(ReturnUrl))
                model.ReturnUrl = ReturnUrl;

            return View(model);
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Microsoft.AspNetCore.Identity.SignInResult result = await _identityService.Login(model);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);
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
            await _identityService.LogOff();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
                return View(model);

            IdentityUserModel user = new IdentityUserModel
            {
                UserName = model.UserName,
                Email = model.Email
            };

            IdentityResult result = await _identityService.RegisterUser(user, model.Password);
            if (result.Succeeded)
            {
                string confirmationCode = await _identityService.GenerateConfirmUserCode(user);
                string callbackUrl = Url.Action(controller: "Account", action: "ConfirmEmail", values: new { userId = user.Id, code = confirmationCode }, protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(email: user.Email, subject: "Confirm Email", htmlMessage: callbackUrl);

                TempData["SuccessMessage"] = "Registration completed. Click on link above the email we sent you just now.";
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
                return RedirectToAction("Index", "Home");

            IdentityUserModel user = await _identityService.GetUserEntityById(userId);
            if (user == null)
                throw new ApplicationException($"Unable to load user with Id '{userId}'.");

            IdentityResult result = await _identityService.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return View("ConfirmEmail");

            TempData["ErrorMessage"] = "Email confirmation failed.";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
    }
}