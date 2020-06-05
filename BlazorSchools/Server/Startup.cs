using BlazorSchools.Server.Data;
using BlazorSchools.Server.Data.EnitityFramework;
using BlazorSchools.Server.Data.Sim;
using BlazorSchools.Server.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BlazorSchools.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            string allowDapper = configuration.GetValue<string>("AllowDapper");
            string allowEF = configuration.GetValue<string>("AllowEF");
            if (allowEF != "1")
            {
                configuration["UseEF"] = "0";
                if (allowDapper != "1")
                    configuration["UseSIM"] = "1";
            }



        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string uri = Configuration.GetValue<string>("SchoolAPI");
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped<ISqlDataAccess, SqlDataAccess>();
            services.AddScoped<SchoolsSqlDataService, SchoolsSqlDataService>();
            services.AddSingleton<SchoolsSimDataService, SchoolsSimDataService>();

            services.AddScoped<SchoolDBContextFactory, SchoolDBContextFactory>();
            services.AddScoped<SchoolEFDataService, SchoolEFDataService>();


            services.AddHttpClient();
            services.AddHttpClient("school", c =>
            {
                c.BaseAddress = new Uri(uri);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();

            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
