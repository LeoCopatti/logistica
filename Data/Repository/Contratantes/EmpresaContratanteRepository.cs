using Core.Domain.Empresa;
using Data.Context;
using Manager.Interfaces.Repositories.Contratantes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository.Contratantes
{
    public class EmpresaContratanteRepository : IEmpresaContratanteRepository
    {
        private readonly DistribuidoraContext _context;

        public EmpresaContratanteRepository(DistribuidoraContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmpresaContratante>> GetEmpresasContratantesAsync()
        {
            return await _context.EmpresasContratantes.AsNoTracking().ToListAsync();
        }

        public async Task<EmpresaContratante> GetEmpresaContratanteAsync(int id)
        {
            return await _context.EmpresasContratantes
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<EmpresaContratante> InsertEmpresaContratanteAsync(EmpresaContratante empresaContratante)
        {
            await _context.EmpresasContratantes.AddAsync(empresaContratante);
            await _context.SaveChangesAsync();
            return empresaContratante;
        }

        public async Task<EmpresaContratante> UpdateEmpresaContratanteAsync(EmpresaContratante empresaContratante)
        {
            var empresaContratanteConsultada = await GetEmpresaContratanteAsync(empresaContratante.Id);
            if (empresaContratanteConsultada == null)
                return null;

            _context.Entry(empresaContratanteConsultada).CurrentValues.SetValues(empresaContratante);
            await _context.SaveChangesAsync();

            return empresaContratanteConsultada;
        }

        public async Task DeleteEmpresaContratanteAsync(int id)
        {
            var empresaContratanteConsultada = await GetEmpresaContratanteAsync(id);
            _context.EmpresasContratantes.Remove(empresaContratanteConsultada);
            await _context.SaveChangesAsync();
        }
    }
}
