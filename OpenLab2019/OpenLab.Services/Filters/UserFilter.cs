using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OpenLab.Infrastructure.Interfaces.PresentationModels;
using OpenLab.Infrastructure.PresentationModels.Web;
using OpenLab.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Services.Filters
{
    public class UserFilter : IAsyncActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IIdentityService _identityService;

        public UserFilter(IHttpContextAccessor httpContextAccessor, IIdentityService identityService = null)
        {
            if (httpContextAccessor != null)
                _httpContextAccessor = httpContextAccessor;
            else
                _httpContextAccessor = new HttpContextAccessor();

            if (identityService != null)
                _identityService = identityService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context == null || next == null || _identityService == null)
                return;

            UserInfoModel webUser = null;

            //To do : before the action executes  

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                IUserModel user = await _identityService.GetUserAsync(_httpContextAccessor.HttpContext.User).ConfigureAwait(false);
                if (user == null)
                    return;

                bool isAdmin = _httpContextAccessor.HttpContext.User.IsInRole("Admin");
                webUser = new UserInfoModel
                {
                    IsAdmin = isAdmin,
                    IsLogged = true,
                    User = user,
                };
            } else
            {
                webUser = new UserInfoModel
                {
                    IsLogged = false,
                    IsAdmin = false,
                    User = null,
                };
            }

            if (!(context.Controller is Controller controller)) return;

            controller.ViewBag.WebUser = webUser;

            await next().ConfigureAwait(false);

            // To do : after the action executes 
        }

    }
}
