using AutoMapper;
using Core.Domain.Entregas;
using Core.Shared.ModelViews;
using Core.Shared.ModelViews.Entregas;
using System;

namespace Manager.Mappings.Entregas
{
    public class EntregadorProfile : Profile
    {
        public EntregadorProfile()
        {
            CreateMap<NovoEntregador, Entregador>()
               .ForMember(c => c.DataCriacao, o => o.MapFrom(x => DateTime.Now))
               .ReverseMap();

            CreateMap<AlteraEntregador, Entregador>()
                 .ForMember(c => c.UltimaAtualizacao, o => o.MapFrom(x => DateTime.Now))
                 .ReverseMap();

            CreateMap<NovoEndereco, Endereco>().ReverseMap();

            CreateMap<NovoTelefone, Telefone>().ReverseMap();


        }
    }
}
