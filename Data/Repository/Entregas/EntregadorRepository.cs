using Core.Domain.Entregas;
using Data.Context;
using Manager.Interfaces.Repositories.Entregas;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository.Entregas
{
    public class EntregadorRepository : IEntregadorRepository
    {
        private readonly DistribuidoraContext _context;

        public EntregadorRepository(DistribuidoraContext context)
        {
            _context = context;
        }

        public async Task DeleteEntregadorAsync(int id)
        {
            var entregadorConsultada = await GetEntregadorAsync(id);
            _context.Entregadores.Remove(entregadorConsultada);
            await _context.SaveChangesAsync();
        }

        public async Task<Entregador> GetEntregadorAsync(int id)
        {
            return await _context.Entregadores
                            .Include(p => p.Telefones)
                            .Include(p => p.Documentos)
                            .Include(p => p.Endereco)
                            .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Entregador>> GetEntregadoresAsync()
        {
            return await _context.Entregadores
                            .Include(p => p.Telefones)
                            .Include(p => p.Documentos)
                            .Include(p => p.Endereco)
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<Entregador> InsertEntregadorAsync(Entregador entregador)
        {
            await _context.Entregadores.AddAsync(entregador);
            await _context.SaveChangesAsync();
            return entregador;
        }

        public async Task<Entregador> UpdateEntregadorAsync(Entregador entregador)
        {
            var entregadorConsultada = await GetEntregadorAsync(entregador.Id);
            if (entregadorConsultada == null)
                return null;

            _context.Entry(entregadorConsultada).CurrentValues.SetValues(entregador);
            entregadorConsultada.Endereco = entregador.Endereco;
            UpdateEntregadorTelefones(entregador, entregadorConsultada);

            await _context.SaveChangesAsync();

            return entregadorConsultada;
        }

        private static void UpdateEntregadorTelefones(Entregador entregador, Entregador entregadorConsultada)
        {
            entregadorConsultada.Telefones.Clear();
            foreach (var telefone in entregador.Telefones)
            {
                entregadorConsultada.Telefones.Add(telefone);
            }
        }
    }
}
