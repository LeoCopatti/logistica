using Core.Domain.Entregas;
using Data.Context;
using Manager.Interfaces.Repositories.Entregas;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.Entregas
{
    public class ValorEntregadorEmpresaRepository : IValorEntregadorEmpresaRepository
    {
        private readonly DistribuidoraContext _context;

        public ValorEntregadorEmpresaRepository(DistribuidoraContext context)
        {
            _context = context;
        }

        public async Task DeleteValorEntregadorEmpresaAsync(int id)
        {
            var valorEntregadorEmpresaConsultada = await GetValorEntregadorEmpresaAsync(id);
            _context.ValoresEntregadorEmpresa.Remove(valorEntregadorEmpresaConsultada);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ValorEntregadorEmpresa>> GetValoresEntregadorEmpresaByEntregadorAsync(int entregadorId)
        {
            return await _context.ValoresEntregadorEmpresa
                .Include(p => p.Entregador)
                .Include(p => p.EmpresaContratante)
                .Where(p => p.Entregador.Id == entregadorId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ValorEntregadorEmpresa> GetValoresEntregadorEmpresaByEmpresaEntregadorAsync(int entregadorId, int empresaId)
        {
            return await _context.ValoresEntregadorEmpresa
                .Include(p => p.Entregador)
                .Include(p => p.EmpresaContratante)
                .SingleOrDefaultAsync(p => p.Entregador.Id == entregadorId && p.EmpresaContratante.Id == empresaId);
        }

        public async Task<ValorEntregadorEmpresa> GetValorEntregadorEmpresaAsync(int id)
        {
            return await _context.ValoresEntregadorEmpresa
                .Include(p => p.Entregador)
                .Include(p => p.EmpresaContratante)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ValorEntregadorEmpresa>> GetValoresEntregadorEmpresaAsync()
        {
            return await _context.ValoresEntregadorEmpresa
                .Include(p => p.Entregador)
                .Include(p => p.EmpresaContratante)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ValorEntregadorEmpresa> InsertValorEntregadorEmpresaAsync(ValorEntregadorEmpresa valorEntregadorEmpresa)
        {
            valorEntregadorEmpresa.Entregador = await _context.Entregadores.FindAsync(valorEntregadorEmpresa.Entregador.Id);
            valorEntregadorEmpresa.EmpresaContratante = await _context.EmpresasContratantes.FindAsync(valorEntregadorEmpresa.EmpresaContratante.Id);
            await _context.ValoresEntregadorEmpresa.AddAsync(valorEntregadorEmpresa);
            await _context.SaveChangesAsync();
            return valorEntregadorEmpresa;
        }

        public async Task<ValorEntregadorEmpresa> UpdateValorEntregadorEmpresaAsync(ValorEntregadorEmpresa valorEntregadorEmpresa)
        {
            var valorEntregadorEmpresaConsultada = await GetValorEntregadorEmpresaAsync(valorEntregadorEmpresa.Id);
            if (valorEntregadorEmpresaConsultada == null)
                return null;

            _context.Entry(valorEntregadorEmpresaConsultada).CurrentValues.SetValues(valorEntregadorEmpresa);
            await _context.SaveChangesAsync();

            return valorEntregadorEmpresaConsultada;
        }
    }
}
