using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenLab.Controllers.Base;
using OpenLab.DAL.EF.Models.Identity;
using OpenLab.Infrastructure.ViewModels;
using OpenLab.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLab.Controllers
{
    public class AccountApiController : BaseApiController
    {
        public AccountApiController(ILogger<AccountApiController> logger, IHttpContextAccessor httpContextAccessor, IIdentityService identityService, IBackofficeService backendService, IEmailService emailSender)
            : base(logger, httpContextAccessor, identityService, backendService, emailSender) { }

        [HttpPost, ActionName("loginUser")]
        public async Task<IActionResult> LoginUser(dynamic data)
        {
            if (data == null)
                return BadRequest("Data not found");

            Microsoft.AspNetCore.Identity.SignInResult result = await IdentityService.Login(data).ConfigureAwait(false);

            if (result.Succeeded)
            {
                if (data.ReturnUrl != null)
                    return Ok(data.ReturnUrl.ToString());
                else
                    return BadRequest("Error loggin in");
            }

            return BadRequest("Error loggin in");
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await IdentityService.LogOff().ConfigureAwait(false);
            return Ok("logged off");
        }

        [HttpPost, ActionName("registerUser")]
        public async Task<IActionResult> RegisterUser(dynamic data)
        {
            if (data == null)
                return BadRequest("Error registering");

            IdentityUserModel user = new IdentityUserModel
            {
                UserName = data.UserName,
                Email = data.Email
            };

            IdentityResult result = result = await IdentityService.RegisterUser(user, data.Password).ConfigureAwait(false);
            if (result.Succeeded)
            {
                string confirmationCode = await IdentityService.GenerateConfirmUserCode(user).ConfigureAwait(false);
                string callbackUrl = Url.Action(controller: "Account", action: "ConfirmEmail", values: new { userId = user.Id, code = confirmationCode }, protocol: Request.Scheme);

                bool sent = await EmailService.SendWelcomeConfirmEmail(user.Email, "Confirm Email", new Uri(callbackUrl, UriKind.Absolute), user.UserName, data.Password, data.FirstName).ConfigureAwait(false);

                if (sent)
                {
                    return Ok("User Registered");
                }
                else
                {
                    return BadRequest("Error sending email, but user registered");
                }
            }
            return BadRequest("Error registering");
        }
    }
}
