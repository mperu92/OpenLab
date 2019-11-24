using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenLab.DAL.EF;
using OpenLab.Services;
using OpenLab.Services.Services;

namespace OpenLab
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Extensions
            services.AddDataAccessServices(Configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
            services.AddAppConfiguration();
            services.AddEmailService();

            // Response gzip compression
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });

            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllersWithViews().AddNewtonsoftJson(); // Without AddNewtonsoftJson actions that produce or receive JSON Objects will return error 406


            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(60); // You can set Time   
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

            services.AddIdentityService();
            services.AddTransient<IBackofficeService, BackofficeService>();
            services.AddTransient<IImageService, ImageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days.
                // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Enable compression (must be before UseStaticFiles)
            app.UseResponseCompression();
            app.UseStaticFiles(new StaticFileOptions()
            {
                // disabling browser cache
                OnPrepareResponse = opr =>
                {
                    opr.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                    opr.Context.Response.Headers.Add("Expires", "-1");
                }
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area}/{controller=Dashboard}/{action=Index}/{id?}");
            });
        }
    }
}
