using Core.Domain.User;
using Data.Context;
using Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DistribuidoraContext _context;

        public UsuarioRepository(DistribuidoraContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            return await _context.Usuarios
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Usuario> GetUsuarioAsync(string login)
        {
            return await _context.Usuarios
                .Include(p => p.Funcoes)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Login == login);
        }

        public async Task<Usuario> InsertUsuarioAsync(Usuario usuario)
        {
            await InsertUsuarioFuncaoAsync(usuario);
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        private async Task InsertUsuarioFuncaoAsync(Usuario usuario)
        {
            var funcoesConsultadas = new List<Funcao>();
            foreach (var funcao in usuario.Funcoes)
            {
                var funcaoConsultada = await _context.Funcoes.FindAsync(funcao.Id);

                funcoesConsultadas.Add(funcaoConsultada);
            }

            usuario.Funcoes = funcoesConsultadas;
        }

        public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
        {
            var usuarioConsultado = await GetUsuarioAsync(usuario.Login);
            if (usuarioConsultado == null)
                return null;

            _context.Entry(usuarioConsultado).CurrentValues.SetValues(usuario);
            await _context.SaveChangesAsync();

            return usuarioConsultado;
        }

        public async Task DeleteUsuarioAsync(string login)
        {
            var usuarioConsultado = await GetUsuarioAsync(login);
            _context.Usuarios.Remove(usuarioConsultado);
            await _context.SaveChangesAsync();
        }
    }
}
