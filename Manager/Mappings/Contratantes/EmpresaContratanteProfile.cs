using AutoMapper;
using Core.Domain.Empresa;
using Core.Shared.ModelViews.Contratantes;
using System;

namespace Manager.Mappings.Contratantes
{
    public class EmpresaContratanteProfile : Profile
    {

        public EmpresaContratanteProfile()
        {
            CreateMap<NovaEmpresaContratante, EmpresaContratante>()
                .ForMember(c => c.DataCriacao, o => o.MapFrom(x => DateTime.Now))
                .ReverseMap();

            CreateMap<AlteraEmpresaContratante, EmpresaContratante>()
                 .ForMember(c => c.UltimaAtualizacao, o => o.MapFrom(x => DateTime.Now))
                 .ReverseMap();
        }
    }
}
