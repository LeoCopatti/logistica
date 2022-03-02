using Core.Domain.Entregas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Interfaces.Repositories.Entregas
{
    public interface IValorEntregadorEmpresaRepository
    {
        Task DeleteValorEntregadorEmpresaAsync(int id);

        Task<IEnumerable<ValorEntregadorEmpresa>> GetValoresEntregadorEmpresaAsync();

        Task<ValorEntregadorEmpresa> GetValorEntregadorEmpresaAsync(int id);

        Task<ValorEntregadorEmpresa> InsertValorEntregadorEmpresaAsync(ValorEntregadorEmpresa valorEntregadorEmpresa);

        Task<ValorEntregadorEmpresa> UpdateValorEntregadorEmpresaAsync(ValorEntregadorEmpresa valorEntregadorEmpresa);

        Task<IEnumerable<ValorEntregadorEmpresa>> GetValoresEntregadorEmpresaByEntregadorAsync(int entregadorId);
        Task<ValorEntregadorEmpresa> GetValoresEntregadorEmpresaByEmpresaEntregadorAsync(int entregadorId, int empresaId);
    }
}
