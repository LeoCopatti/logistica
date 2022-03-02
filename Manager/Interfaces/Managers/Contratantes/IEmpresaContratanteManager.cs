using Core.Domain.Empresa;
using Core.Shared.ModelViews.Contratantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Interfaces.Managers.Contratantes
{
    public interface IEmpresaContratanteManager
    {
        Task DeleteEmpresaContratanteAsync(int id);
        Task<IEnumerable<EmpresaContratante>> GetEmpresasContratantesAsync();
        Task<EmpresaContratante> GetEmpresaContratanteAsync(int id);
        Task<EmpresaContratante> InsertEmpresaContratanteAsync(NovaEmpresaContratante novaEmpresaContratante);
        Task<EmpresaContratante> UpdateEmpresaContratanteAsync(AlteraEmpresaContratante aleteraEmpresaContratante);
    }
}
