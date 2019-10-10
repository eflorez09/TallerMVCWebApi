using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TallerMVCWebApi.Authorization;

namespace TallerMVCWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.LoginPath = "/Home/Login";
                options.LogoutPath = "/Home/Logout";
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true
                };
            });

            CreateIdentityIfNotCreated(services);

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseInMemoryDatabase("Identity"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void CreateIdentityIfNotCreated(IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var existingUserManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();

                if (existingUserManager == null)
                {
                    services.AddIdentity<IdentityUser, IdentityRole>()
                        .AddDefaultUI(UIFramework.Bootstrap4)
                        .AddEntityFrameworkStores<AppIdentityDbContext>()
                        .AddDefaultTokenProviders();
                }
            }
        }
    }
}