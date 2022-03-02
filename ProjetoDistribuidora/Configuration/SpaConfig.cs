using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ProjetoDistribuidora.Configuration
{
    public static class SpaConfig
    {
        public static void AddSpaConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "reactjs/build";
            });
        }

        public static void UseSpaConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "reactjs";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}