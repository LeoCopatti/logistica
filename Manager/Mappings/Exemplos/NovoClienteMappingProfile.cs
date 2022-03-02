using AutoMapper;
using Core.Domain.Exemplos;
using Core.Shared.ModelViews;
using System;

namespace Manager.Mappings
{
    public class NovoClienteMappingProfile : Profile
    {
        public NovoClienteMappingProfile()
        {
            CreateMap<NovoCliente, Cliente>()
                .ForMember(c => c.DataCriacao, o => o.MapFrom(x => DateTime.Now))
                .ForMember(c => c.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));

            CreateMap<NovoTelefoneExemplo, TelefoneExemplo>();
        }
    }
}
