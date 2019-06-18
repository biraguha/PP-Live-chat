using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livechat.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace livechat
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
            services.AddCors(o => o.AddPolicy("CorsPolicy", options =>
            {
                options
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:4200")
                    .AllowCredentials();
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSignalR();
            // services.AddSpaStaticFiles(configuration =>
            // {
            //     configuration.RootPath = "ClientApp/dist";
            // });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            // app.UseSpaStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseSignalR(routes => routes.MapHub<ChatHub>("/chat"));
            app.UseMvc();

            app.UseSpa(spa =>
            {

                // if (env.IsProduction())
                // {
                //     spa.Options.SourcePath = "ClientApp/dist";
                // }

                // if (env.IsProduction())
                // {
                //     spa.UseSpaPrerendering(options => 
                //     {
                //         options.BootModulePath = $"{ spa.Options.SourcePath }/dist/server/main.js";
                //         options.ExcludeUrls = new [] { "/sockjs-node" };
                //     });
                // }

                if (env.IsDevelopment())
                {
                    // spa.Options.SourcePath = "ClientApp";
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
