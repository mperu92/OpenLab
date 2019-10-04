using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenLab.DAL.EF.Contexts;
using OpenLab.DAL.EF.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.DAL.EF
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<OpenLabDbContext>(options =>
                options
                .UseSqlServer(connectionString)
                    .UseLazyLoadingProxies()) // Add Microsoft.EntityFrameworkCore.Proxies
                .AddIdentity<IdentityUserModel, IdentityRoleModel>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<OpenLabDbContext>();

            // Add Identity Options
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
            });

            // Had to install Microsoft.EntityFrameworkCore.Design directly on Web App.
            // Without that reference migrations didn't work :(
        }

        public static void AddAppConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IAppConfiguration, AppConfiguration>();
        }
    }
}
