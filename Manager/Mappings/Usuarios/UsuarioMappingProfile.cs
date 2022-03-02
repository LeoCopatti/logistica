using AutoMapper;
using Core.Domain.User;
using Core.Shared.ModelViews;

namespace Manager.Mappings
{
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            CreateMap<Usuario, UsuarioView>().ReverseMap();
            CreateMap<Usuario, NovoUsuario>().ReverseMap();
            CreateMap<Funcao, FuncaoView>().ReverseMap();
            CreateMap<Funcao, ReferenciaFuncao>().ReverseMap();
            CreateMap<Usuario, UsuarioLogado>().ReverseMap();
        }
    }
}
