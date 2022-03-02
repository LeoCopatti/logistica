using AutoMapper;
using Core.Domain.Exemplos;
using Core.Shared.ModelViews;
using System;

namespace Manager.Mappings
{
    public class AlteraClienteMappingProfile : Profile
    {
        public AlteraClienteMappingProfile()
        {
            CreateMap<AlteraCliente, Cliente>()
                .ForMember(c => c.UltimaAtualizacao, o => o.MapFrom(x => DateTime.Now))
                .ForMember(c => c.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date)); ;
        }
    }
}
