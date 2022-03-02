using Core.Domain.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task DeleteUsuarioAsync(string login);

        Task<Usuario> GetUsuarioAsync(string login);

        Task<IEnumerable<Usuario>> GetUsuariosAsync();

        Task<Usuario> InsertUsuarioAsync(Usuario usuario);

        Task<Usuario> UpdateUsuarioAsync(Usuario usuario);
    }
}
