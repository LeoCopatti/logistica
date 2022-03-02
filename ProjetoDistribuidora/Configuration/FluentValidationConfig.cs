using FluentValidation.AspNetCore;
using Manager.Validator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjetoDistribuidora.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddFluentValidation(f =>
                {
                    f.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                    f.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                    f.RegisterValidatorsFromAssemblyContaining<NovoEnderecoValidator>();
                    f.RegisterValidatorsFromAssemblyContaining<NovoTelefoneValidator>();
                    f.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                });
        }
    }
}
