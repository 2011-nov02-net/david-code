using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace HelloAspNetCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // this method is for 1) configuring middleware before plugging it in
            // and 2) adding "services" to the DI (dependency injection) container


            services.AddControllersWithViews(); // add controllers to the list of things ASP.NET Core will understand
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGet("/index.html", async context =>
                {
                    //get the file named index.html
                    string path = context.Request.Path.ToString().Substring(1);
                    string index = File.ReadAllText(path);
                    await context.Response.WriteAsync(index);
                });

                //ASP.NET Core MVC is when we use a specific subset of middlewares/classes/practices
                endpoints.MapControllerRoute(
                    name: "hello-controller",
                    pattern: "hello",
                    defaults: new { controller = "Hello", action = "Action1" });

                endpoints.MapControllerRoute(
                    name: "hello-controller2",
                    pattern: "hello/{param1}/{param2:int?}",
                    defaults: new { controller = "Hello", action = "ParameterizedAction" });
                // route parameters can be constrained ex ":int", if the given value doesn't match
                //  the route as a whole does not match
                // the question mark makes it optional
                // add "=something"

                // a given request is matched against each of these route patterns in turn until the first one that matches is found.

                // Usually
                endpoints.MapControllerRoute(
                    name: "hello-controller-generic",
                    pattern: "hi/{action=Action1}/{param1?}/{param2:int?}",
                    defaults: new { controller = "Hello" });
                // a route parameter named action is looked at the decide whgich action method is called in the first place

                endpoints.MapControllerRoute(
                    name: "hello-controller-generic",
                    pattern: "{controller=hello}/{action=Action1}/{param1?}/{param2:int?}");
                //this is a generic route, defines controller and action
            });

            app.Use(async (context, next) =>
            {
                // request processing logic before the next middleware runs
                await next();
                // request processing logic that runs after any later middlewares
            });

            app.Run(async context =>
            {
                // this object has all the details of the request
                HttpRequest request = context.Request;

                // we can modify this object to set up the response
                HttpResponse response = context.Response;

                if (context.Request.Path == "/HTML/linkedpage.html")
                {
                    string path = context.Request.Path.ToString().Substring(1);
                    string linkedpage = File.ReadAllText(path);
                    response.ContentType = "text/html";
                    await context.Response.WriteAsync(linkedpage);
                }
            });
        }
    }
}
