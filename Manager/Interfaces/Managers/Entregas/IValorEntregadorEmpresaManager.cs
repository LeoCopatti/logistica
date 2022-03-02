using Core.Domain.Entregas;
using Core.Shared.ModelViews.Entregas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Interfaces.Managers.Entregas
{
    public interface IValorEntregadorEmpresaManager
    {
        Task DeleteValorEntregadorEmpresaAsync(int id);

        Task<IEnumerable<ValorEntregadorEmpresa>> GetValoresEntregadorEmpresaAsync();

        Task<ValorEntregadorEmpresa> GetValorEntregadorEmpresaAsync(int id);

        Task<IEnumerable<ValorEntregadorEmpresa>> GetValoresEntregadorEmpresaByEntregadorAsync(int entregadorId);

        Task<ValorEntregadorEmpresa> InsertValorEntregadorEmpresaAsync(NovoValorEntregadorEmpresa novoValorEntregadorEmpresa);

        Task<ValorEntregadorEmpresa> UpdateValorEntregadorEmpresaAsync(AlteraValorEntregadorEmpresa alteraValorEntregadorEmpresa);
        Task<ValorEntregadorEmpresa> GetValoresEntregadorEmpresaByEmpresaEntregadorAsync(int entregadorId, int empresaId);
    }
}
