using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RoutingAspNetCoreDemo.Conventional
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
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //In ASP.NET Core 3.0, we use UseEndpoints instead of UseMvc, UseSignalR, UseRazorPages, etc.
            app.UseEndpoints(endpoints =>
            {
                //The below method establishes a "convention" route.  
                //It will match anything with the format controller/action/id, where id is optional
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //This method establishes a different "convention" route, one that only goes to the Account/Index action.
                endpoints.MapControllerRoute("account", "account/{id?}",
                                                defaults: new { controller = "Account", action = "Index" });

                endpoints.MapControllerRoute("user", "user/{id?}",
                                             defaults: new { controller = "User", action = "Index" });
            });
        }
    }
}