using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Services.Filters
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class CustomActionFilterAttribute : Attribute, IActionFilter, IOrderedFilter
    {
        public int Order { get; set; }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            // TO DO before action 
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                
            }

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // TO DO after action executes
        }
    }
}
