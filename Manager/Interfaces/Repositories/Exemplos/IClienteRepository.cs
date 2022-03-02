using Core.Domain.Exemplos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Interfaces
{
    public interface IClienteRepository
    {
        Task DeleteClienteAsync(int id);
        Task<Cliente> GetClienteAsync(int id);
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> InsertClienteAsync(Cliente cliente);
        Task<Cliente> UpdateClienteAsync(Cliente cliente);
    }
}
