using Core.Domain.Exemplos;
using Data.Context;
using Manager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DistribuidoraContext _context;

        public ClienteRepository(DistribuidoraContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _context.Clientes
                .Include(p => p.Telefones)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await _context.Clientes
                .Include(p => p.Telefones)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            var clienteConsultado = await GetClienteAsync(cliente.Id);
            if (clienteConsultado == null)
                return null;

            _context.Entry(clienteConsultado).CurrentValues.SetValues(cliente);
            await _context.SaveChangesAsync();

            return clienteConsultado;
        }

        public async Task DeleteClienteAsync(int id)
        {
            var clienteConsultado = await GetClienteAsync(id);
            _context.Clientes.Remove(clienteConsultado);
            await _context.SaveChangesAsync();
        }
    }
}
