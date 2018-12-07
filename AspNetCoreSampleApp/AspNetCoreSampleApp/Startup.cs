using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspNetCoreSampleApp.Core;
using Microsoft.EntityFrameworkCore;
using AspNetCoreSampleApp.Service.Repositories;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http.Features;
using AspNetCoreSampleApp.Utils;

namespace AspNetCoreSampleApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //custom Add
            //var builder = new ConfigurationBuilder()
            //  .SetBasePath(env.ContentRootPath)
            //  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            //  .AddEnvironmentVariables();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add Custom for use session.
            services.AddMemoryCache();
            services.AddSession();

            services.AddDbContext<DataContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DataContext")));
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            //upload File path
            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseMiddleware(typeof(ErrorHandlingMiddleware));

                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseMiddleware(typeof(ErrorHandlingMiddleware));

                app.UseExceptionHandler("/Home/Error");
            }

            //Custom Add for max file size
            //app.Run(context =>
            //{
            //    context.Features.Get<IHttpMaxRequestBodySizeFeature>().MaxRequestBodySize = null;
            //});
            //app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
            //{
            //    context.Features.Get<IHttpMaxRequestBodySizeFeature>().MaxRequestBodySize = null;
            //    //TODO: take next steps
            //});
            app.UseExceptionHandler("/Home/Error");
            app.UseMvc();


            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
