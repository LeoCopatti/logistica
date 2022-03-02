using Core.Domain.Entregas;
using Core.Shared.ModelViews.Entregas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Interfaces.Managers.Entregas
{
    public interface IEntregaManager
    {
        Task DeleteEntregaAsync(int id);

        Task<IEnumerable<Entrega>> GetEntregasAsync();

        Task<Entrega> GetEntregaAsync(int id);

        Task<Entrega> InsertEntregasAsync(NovaEntrega novaEntrega);

        Task<Entrega> UpdateEntregasAsync(AlteraEntrega alteraEmpresaContratante);
    }
}
