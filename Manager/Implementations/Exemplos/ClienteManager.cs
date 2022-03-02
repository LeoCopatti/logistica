using AutoMapper;
using Core.Domain.Exemplos;
using Core.Shared.ModelViews;
using Manager.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Implementations
{
    public class ClienteManager : IClienteManager
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteManager(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _clienteRepository.GetClientesAsync();
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await _clienteRepository.GetClienteAsync(id);
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _clienteRepository.DeleteClienteAsync(id);
        }

        public async Task<Cliente> InsertClienteAsync(NovoCliente novoCliente)
        {
            var cliente = _mapper.Map<Cliente>(novoCliente);
            return await _clienteRepository.InsertClienteAsync(cliente);
        }

        public async Task<Cliente> UpdateClienteAsync(AlteraCliente clienteAtualizado)
        {
            var cliente = _mapper.Map<Cliente>(clienteAtualizado);
            return await _clienteRepository.UpdateClienteAsync(cliente);
        }
    }
}
