using Core.Domain.Empresa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Interfaces.Repositories.Contratantes
{
    public interface IEmpresaContratanteRepository
    {
        Task DeleteEmpresaContratanteAsync(int id);
        Task<IEnumerable<EmpresaContratante>> GetEmpresasContratantesAsync();
        Task<EmpresaContratante> GetEmpresaContratanteAsync(int id);
        Task<EmpresaContratante> InsertEmpresaContratanteAsync(EmpresaContratante empresaContratante);
        Task<EmpresaContratante> UpdateEmpresaContratanteAsync(EmpresaContratante empresaContratante);
    }
}
