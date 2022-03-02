using Core.Domain.Entregas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Interfaces.Repositories.Entregas
{
    public interface IEntregadorRepository
    {
        Task DeleteEntregadorAsync(int id);

        Task<IEnumerable<Entregador>> GetEntregadoresAsync();

        Task<Entregador> GetEntregadorAsync(int id);

        Task<Entregador> InsertEntregadorAsync(Entregador novoEntregador);

        Task<Entregador> UpdateEntregadorAsync(Entregador aleteraEntregador);
    }
}
