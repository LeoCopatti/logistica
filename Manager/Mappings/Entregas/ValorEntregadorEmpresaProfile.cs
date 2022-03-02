using AutoMapper;
using Core.Domain.Empresa;
using Core.Domain.Entregas;
using Core.Shared.ModelViews.Entregas;
using System;

namespace Manager.Mappings.Entregas
{
    public class ValorEntregadorEmpresaProfile : Profile
    {
        public ValorEntregadorEmpresaProfile()
        {
            CreateMap<NovoValorEntregadorEmpresa, ValorEntregadorEmpresa>()
               .ForMember(c => c.DataCriacao, o => o.MapFrom(x => DateTime.Now))
               .ReverseMap();

            CreateMap<AlteraValorEntregadorEmpresa, ValorEntregadorEmpresa>()
                 .ForMember(c => c.UltimaAtualizacao, o => o.MapFrom(x => DateTime.Now))
                 .ReverseMap();

            CreateMap<ReferenciaEntregador, Entregador>().ReverseMap();
            CreateMap<ReferenciaEmpresaContratante, EmpresaContratante>().ReverseMap();
        }
    }
}
