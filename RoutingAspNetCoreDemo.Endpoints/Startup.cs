using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RoutingAspNetCoreDemo.Endpoints.RouteConstraints;
using RoutingAspNetCoreDemo.Endpoints.Transformers;

namespace RoutingAspNetCoreDemo.Endpoints
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
            services.AddMvc().AddMvcOptions(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
            });
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

            app.UseEndpoints(endpoints =>
            {
                //An example of a basic route
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //An example of a route using MapGet.  This route will match any GET request
                //to the /test/get location.
                endpoints.MapGet("/test/get", async context => 
                {
                    context.Response.Redirect("/user/index");
                    await context.Response.CompleteAsync();
                });

                endpoints.MapControllerRoute(
                    name: "userdetails",
                    pattern: "user/{id}/{**name}",
                    defaults: new {controller = "User", action = "Details"},
                    constraints: new { id = new RequiredPositiveIntRouteConstraint(),
                                        name = new RequiredRouteConstraint() }
                );
            });
        }
    }
}
