using AutoMapper;
using Core.Domain.Entregas;
using Core.Shared.ModelViews.Entregas;
using System;

namespace Manager.Mappings.Entregas
{
    public class EntregaProfile : Profile
    {
        public EntregaProfile()
        {
            CreateMap<NovaEntrega, Entrega>()
               .ForMember(c => c.DataCriacao, o => o.MapFrom(x => DateTime.Now))
               .ReverseMap();

            CreateMap<AlteraEntrega, Entrega>()
                 .ForMember(c => c.UltimaAtualizacao, o => o.MapFrom(x => DateTime.Now))
                 .ReverseMap();
        }
    }
}
