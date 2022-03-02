using Core.Domain.Entregas;
using Data.Context;
using Manager.Interfaces.Repositories.Entregas;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository.Entregas
{
    public class EntregaRepository : IEntregaRepository
    {
        private readonly DistribuidoraContext _context;

        public EntregaRepository(DistribuidoraContext context)
        {
            _context = context;
        }

        public async Task DeleteEntregaAsync(int id)
        {
            var entregaConsultada = await GetEntregaAsync(id);
            _context.Entregas.Remove(entregaConsultada);
            await _context.SaveChangesAsync();
        }

        public async Task<Entrega> GetEntregaAsync(int id)
        {
            return await _context.Entregas
                .Include(p => p.Entregador)
                .Include(p => p.EmpresaContratante)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Entrega>> GetEntregasAsync()
        {
            return await _context.Entregas
                .Include(p => p.Entregador)
                .Include(p => p.EmpresaContratante)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Entrega> InsertEntregasAsync(Entrega entrega)
        {
            entrega.Entregador = await _context.Entregadores.FindAsync(entrega.Entregador.Id);
            entrega.EmpresaContratante = await _context.EmpresasContratantes.FindAsync(entrega.EmpresaContratante.Id);
            await _context.Entregas.AddAsync(entrega);
            await _context.SaveChangesAsync();
            return entrega;
        }

        public async Task<Entrega> UpdateEntregasAsync(Entrega entrega)
        {
            var entregaConsultada = await GetEntregaAsync(entrega.Id);
            if (entregaConsultada == null)
                return null;

            _context.Entry(entregaConsultada).CurrentValues.SetValues(entrega);
            await _context.SaveChangesAsync();

            return entregaConsultada;
        }
    }
}
