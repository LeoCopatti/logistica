using AutoMapper;
using Core.Domain.Entregas;
using Core.Shared.ModelViews.Entregas;
using Manager.Interfaces.Managers.Entregas;
using Manager.Interfaces.Repositories.Entregas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Implementations.Entregas
{
    public class EntregadorManager : IEntregadorManager
    {
        private readonly IMapper _mapper;
        private readonly IEntregadorRepository _repository;

        public EntregadorManager(IMapper mapper, IEntregadorRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task DeleteEntregadorAsync(int id)
        {
            await _repository.DeleteEntregadorAsync(id);
        }

        public async Task<Entregador> GetEntregadorAsync(int id)
        {
            return await _repository.GetEntregadorAsync(id);
        }

        public async Task<IEnumerable<Entregador>> GetEntregadoresAsync()
        {
            return await _repository.GetEntregadoresAsync();
        }

        public async Task<Entregador> InsertEntregadorAsync(NovoEntregador novoEntregador)
        {
            return await _repository.InsertEntregadorAsync(_mapper.Map<Entregador>(novoEntregador));
        }

        public async Task<Entregador> UpdateEntregadorAsync(AlteraEntregador alteraEntregador)
        {
            return await _repository.UpdateEntregadorAsync(_mapper.Map<Entregador>(alteraEntregador));
        }
    }
}
