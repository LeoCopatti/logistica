using Core.Domain.Entregas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Interfaces.Repositories.Entregas
{
    public interface IEntregaRepository
    {
        Task DeleteEntregaAsync(int id);

        Task<IEnumerable<Entrega>> GetEntregasAsync();

        Task<Entrega> GetEntregaAsync(int id);

        Task<Entrega> InsertEntregasAsync(Entrega entrega);

        Task<Entrega> UpdateEntregasAsync(Entrega entrega);
    }
}
