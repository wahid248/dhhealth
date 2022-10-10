using System;
using System.Collections.Generic;
using BundlerMinifier.TagHelpers;
using Core.Abstruct.Base;
using Core.Entities.Identity;
using Data.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Services;

namespace Web
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
            // DB configuration(DB name : DhHealthDb)
            services.AddDbContextPool<DataContext>(opt => opt.UseSqlServer(Environment.GetEnvironmentVariable("DhHealthConnection")), poolSize: 25);

            // DI configuration
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(EmailService));

            // Identity configuration
            services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
            {
                // Password settings
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequiredUniqueChars = 0;

                // Lockout settings
                //opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                //opt.Lockout.MaxFailedAccessAttempts = 5;
                //opt.Lockout.AllowedForNewUsers = true;

                // User settings
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                opt.User.RequireUniqueEmail = false;
                opt.SignIn.RequireConfirmedAccount = true;
            })
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);

                opt.LoginPath = "/Account/Login";
                opt.AccessDeniedPath = "/Account/AccessDenied";
                opt.SlidingExpiration = true;
            });

            services.AddAntiforgery(opt =>
            {
                opt.Cookie.Name = "AntiforgeryCookie";
                opt.HeaderName = "AntiforgeryCookie";
            });

            services.Configure<GzipCompressionProviderOptions>(opt => 
            {
                opt.Level = System.IO.Compression.CompressionLevel.Optimal;
            });

            services.AddBundles(opt =>
            {
                opt.AppendVersion = true;
            });

            services.AddResponseCompression(opt =>
            {
                IEnumerable<string> mimeTypes = new[]
                {
                    "text/plain",
                    "text/html",
                    "text/css",
                    "font/woff2",
                    "application/x-font-ttf",
                    "application/javascript",
                    "image/x-icon",
                    //"image/png",
                    "image/svg+xml"
                };

                opt.EnableForHttps = true;
                opt.MimeTypes = mimeTypes;
                opt.Providers.Add<GzipCompressionProvider>();
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {
            context.Database.Migrate();

            app.UseHostFiltering();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                await Data.Utilities.ApplicationDbInitializer.SeedUserAsync(app.ApplicationServices);
                await next();
            });

            app.UseRewriter(new RewriteOptions()
               //.AddRedirectToWww()
               .AddRedirectToHttps()
            );

            app.UseResponseCompression();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
