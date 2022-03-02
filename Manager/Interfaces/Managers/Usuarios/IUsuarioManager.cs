using Core.Domain.User;
using Core.Shared.ModelViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Interfaces.Managers
{
    public interface IUsuarioManager
    {
        Task DeleteUsuarioAsync(string login);

        Task<UsuarioView> GetUsuarioAsync(string login);

        Task<IEnumerable<UsuarioView>> GetUsuariosAsync();

        Task<UsuarioView> InsertUsuarioAsync(NovoUsuario novoUsuario);

        Task<UsuarioView> UpdateUsuarioAsync(Usuario usuario);

        Task<UsuarioLogado> ValidaUsuarioEGeraTokenAsync(Usuario usuario);
    }
}
