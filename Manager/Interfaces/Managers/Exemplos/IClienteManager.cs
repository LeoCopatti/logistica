using Core.Domain.Exemplos;
using Core.Shared.ModelViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Interfaces
{
    public interface IClienteManager
    {
        Task DeleteClienteAsync(int id);
        Task<Cliente> GetClienteAsync(int id);
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> InsertClienteAsync(NovoCliente novoCliente);
        Task<Cliente> UpdateClienteAsync(AlteraCliente clienteAtualizado);
    }
}
