using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Services.Filters
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class CustomActionFilter : Attribute, IActionFilter, IOrderedFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomActionFilter(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor != null)
                _httpContextAccessor = httpContextAccessor;
            else
                _httpContextAccessor = new HttpContextAccessor();
        }

        public int Order { get; set; }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string s = "is not logged";

            // TO DO before action executes
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                s = "is logged";
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // TO DO after action executes
        }
    }
}
