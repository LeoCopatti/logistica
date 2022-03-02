using AutoMapper;
using Core.Domain.Empresa;
using Core.Shared.ModelViews.Contratantes;
using Manager.Interfaces.Managers.Contratantes;
using Manager.Interfaces.Repositories.Contratantes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Implementations.Contratantes
{
    public class EmpresaContratanteManager : IEmpresaContratanteManager
    {
        private readonly IMapper _mapper;
        private readonly IEmpresaContratanteRepository _repository;

        public EmpresaContratanteManager(IMapper mapper, IEmpresaContratanteRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task DeleteEmpresaContratanteAsync(int id)
        {
            return _repository.DeleteEmpresaContratanteAsync(id);
        }

        public Task<IEnumerable<EmpresaContratante>> GetEmpresasContratantesAsync()
        {
            return _repository.GetEmpresasContratantesAsync();
        }

        public Task<EmpresaContratante> GetEmpresaContratanteAsync(int id)
        {
            return _repository.GetEmpresaContratanteAsync(id);
        }

        public Task<EmpresaContratante> InsertEmpresaContratanteAsync(NovaEmpresaContratante novaEmpresaContratante)
        {
            var empresaContratante = _mapper.Map<EmpresaContratante>(novaEmpresaContratante);
            return _repository.InsertEmpresaContratanteAsync(empresaContratante);
        }

        public Task<EmpresaContratante> UpdateEmpresaContratanteAsync(AlteraEmpresaContratante alteraEmpresaContratante)
        {
            var empresaContratante = _mapper.Map<EmpresaContratante>(alteraEmpresaContratante);
            return _repository.UpdateEmpresaContratanteAsync(empresaContratante);
        }
    }
}
