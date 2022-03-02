using Core.Domain.Entregas;
using Core.Shared.ModelViews.Entregas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Interfaces.Managers.Entregas
{
    public interface IEntregadorManager
    {
        Task DeleteEntregadorAsync(int id);

        Task<IEnumerable<Entregador>> GetEntregadoresAsync();

        Task<Entregador> GetEntregadorAsync(int id);

        Task<Entregador> InsertEntregadorAsync(NovoEntregador novoEntregador);

        Task<Entregador> UpdateEntregadorAsync(AlteraEntregador alteraEntregador);
    }
}
