using Manager.Mappings;
using Manager.Mappings.Contratantes;
using Manager.Mappings.Entregas;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetoDistribuidora.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NovoClienteMappingProfile), 
                                   typeof(AlteraClienteMappingProfile),
                                   typeof(UsuarioMappingProfile),
                                   typeof(EmpresaContratanteProfile),
                                   typeof(EntregadorProfile),
                                   typeof(EntregaProfile),
                                   typeof(ValorEntregadorEmpresaProfile));
        }
    }
}
