using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetProductsMVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GetProductsMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            //services.AddAuthorization(options =>
            //{
            //    var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
            //        CookieAuthenticationDefaults.AuthenticationScheme,
            //        JwtBearerDefaults.AuthenticationScheme);
            //        defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
            //        options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            //});


            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddHttpClient();

            //named httpClient for generating token
            services.AddHttpClient("Auth", client =>
            {
                client.BaseAddress = new Uri("https://auth.simplestore.io/connect/token");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
            });

            //named httpClient for simplestore api
            services.AddHttpClient("simplestore", client =>
            {
                client.BaseAddress = new Uri("https://api.simplestore.dev/");           
            });

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthService, AuthService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
            //app.UseAuthentication();
            //app.Use(async (context, next) =>
            //{
            //    await next();
            //    var bearerAuth = context.Request.Headers["Authorization"]
            //        .FirstOrDefault()?.StartsWith("Bearer ") ?? false;
            //    if (context.Response.StatusCode == 401
            //        && !context.User.Identity.IsAuthenticated
            //        && !bearerAuth)
            //    {
            //        await context.ChallengeAsync("oidc");
            //    }
            //});

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
