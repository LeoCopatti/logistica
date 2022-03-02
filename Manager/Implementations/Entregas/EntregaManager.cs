using AutoMapper;
using Core.Domain.Entregas;
using Core.Shared.ModelViews.Entregas;
using Manager.Interfaces.Managers.Entregas;
using Manager.Interfaces.Repositories.Entregas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Implementations.Entregas
{
    public class EntregaManager : IEntregaManager
    {
        private readonly IMapper _mapper;
        private readonly IEntregaRepository _repository;

        public EntregaManager(IMapper mapper, IEntregaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task DeleteEntregaAsync(int id)
        {
            await _repository.DeleteEntregaAsync(id);
        }

        public async Task<Entrega> GetEntregaAsync(int id)
        {
            return await _repository.GetEntregaAsync(id);
        }

        public async Task<IEnumerable<Entrega>> GetEntregasAsync()
        {
            return await _repository.GetEntregasAsync();
        }

        public async Task<Entrega> InsertEntregasAsync(NovaEntrega novaEntrega)
        {
            return await _repository.InsertEntregasAsync(_mapper.Map<Entrega>(novaEntrega));
        }

        public async Task<Entrega> UpdateEntregasAsync(AlteraEntrega alteraEmpresaContratante)
        {
            return await _repository.UpdateEntregasAsync(_mapper.Map<Entrega>(alteraEmpresaContratante));
        }
    }
}
