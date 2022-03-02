using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ProjetoDistribuidora.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo() { Title = "Distribuidora", Version = "v1" });
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "Insira o token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement 
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference= new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id ="Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
            });
        }

        public static void UserSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.RoutePrefix = "/docs";
                s.SwaggerEndpoint("./swagger/v1/swagger.json", "Distribuidora V1");
            });
        }
    }
}
