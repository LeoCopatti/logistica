using AutoMapper;
using Core.Domain.Entregas;
using Core.Shared.ModelViews.Entregas;
using Manager.Interfaces.Managers.Entregas;
using Manager.Interfaces.Repositories.Entregas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Implementations.Entregas
{
    public class ValorEntregadorEmpresaManager : IValorEntregadorEmpresaManager
    {
        private readonly IMapper _mapper;
        private readonly IValorEntregadorEmpresaRepository _repository;

        public ValorEntregadorEmpresaManager(IMapper mapper, IValorEntregadorEmpresaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task DeleteValorEntregadorEmpresaAsync(int id)
        {
            await _repository.DeleteValorEntregadorEmpresaAsync(id);
        }

        public async Task<IEnumerable<ValorEntregadorEmpresa>> GetValoresEntregadorEmpresaByEntregadorAsync(int entregadorId)
        {
            return await _repository.GetValoresEntregadorEmpresaByEntregadorAsync(entregadorId);
        }

        public async Task<ValorEntregadorEmpresa> GetValoresEntregadorEmpresaByEmpresaEntregadorAsync(int entregadorId, int empresaId)
        {
            return await _repository.GetValoresEntregadorEmpresaByEmpresaEntregadorAsync(entregadorId, empresaId);
        }

        public async Task<ValorEntregadorEmpresa> GetValorEntregadorEmpresaAsync(int id)
        {
            return await _repository.GetValorEntregadorEmpresaAsync(id);
        }

        public async Task<IEnumerable<ValorEntregadorEmpresa>> GetValoresEntregadorEmpresaAsync()
        {
            return await _repository.GetValoresEntregadorEmpresaAsync();
        }

        public async Task<ValorEntregadorEmpresa> InsertValorEntregadorEmpresaAsync(NovoValorEntregadorEmpresa novoValorEntregadorEmpresa)
        {
            return await _repository.InsertValorEntregadorEmpresaAsync(_mapper.Map<ValorEntregadorEmpresa>(novoValorEntregadorEmpresa));
        }

        public async Task<ValorEntregadorEmpresa> UpdateValorEntregadorEmpresaAsync(AlteraValorEntregadorEmpresa alteraValorEntregadorEmpresa)
        {
            return await _repository.UpdateValorEntregadorEmpresaAsync(_mapper.Map<ValorEntregadorEmpresa>(alteraValorEntregadorEmpresa));
        }
    }
}
