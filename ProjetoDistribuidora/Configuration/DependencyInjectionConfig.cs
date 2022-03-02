using Data.Repository;
using Data.Repository.Contratantes;
using Data.Repository.Entregas;
using Data.Services.Excel;
using Manager.Implementations;
using Manager.Implementations.Contratantes;
using Manager.Implementations.Entregas;
using Manager.Interfaces;
using Manager.Interfaces.Managers;
using Manager.Interfaces.Managers.Contratantes;
using Manager.Interfaces.Managers.Entregas;
using Manager.Interfaces.Repositories;
using Manager.Interfaces.Repositories.Contratantes;
using Manager.Interfaces.Repositories.Entregas;
using Manager.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetoDistribuidora.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteManager, ClienteManager>();
            services.AddScoped<IUsuarioManager, UsuarioManager>();
            services.AddScoped<IEmpresaContratanteManager, EmpresaContratanteManager>();
            services.AddScoped<IEntregadorManager, EntregadorManager>();
            services.AddScoped<IEntregaManager, EntregaManager>();
            services.AddScoped<IValorEntregadorEmpresaManager, ValorEntregadorEmpresaManager>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEmpresaContratanteRepository, EmpresaContratanteRepository>();
            services.AddScoped<IEntregadorRepository, EntregadorRepository>();
            services.AddScoped<IEntregaRepository, EntregaRepository>();
            services.AddScoped<IValorEntregadorEmpresaRepository, ValorEntregadorEmpresaRepository>();
            services.AddScoped<IExportExcelService, ExportExcelService>();
        }
    }
}
