using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoDistribuidora.Configuration;

namespace ProjetoDistribuidora
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
            services.AddCors(action => action.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddControllers();
            services.AddJwtConfiguration(Configuration);
            services.AddFluentValidationConfiguration();
            services.AddSwaggerConfiguration();
            services.AddDependencyInjectionConfiguration();
            services.AddAutoMapperConfiguration();
            services.AddDatabaseConfiguration(Configuration);
            services.AddSpaConfiguration(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/error");

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors();
            app.UserSwaggerConfiguration();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseJwtConfiguration();
            app.UseDatabaseConfiguration();
            app.UseSpaConfiguration(env);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}