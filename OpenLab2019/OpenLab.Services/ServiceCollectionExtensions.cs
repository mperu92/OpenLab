using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using OpenLab.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEmailService(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();
        }

        public static void AddIdentityService(this IServiceCollection services)
        {
            services.AddTransient<IIdentityService, IdentityService>();
        }
    }
}
