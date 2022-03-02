using Core.Shared.ModelViews;
using Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ProjetoDistribuidora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteManager _clienteManager;
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(IClienteManager clienteManager, ILogger<ClientesController> logger)
        {
            _clienteManager = clienteManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _clienteManager.GetClientesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _clienteManager.GetClienteAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(NovoCliente cliente)
        {
            _logger.LogInformation("Foi solicitado a criação de um novo cliente");
            var clienteInserido = await _clienteManager.InsertClienteAsync(cliente);
            return CreatedAtAction(nameof(Get), new { id = clienteInserido.Id }, clienteInserido);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlteraCliente cliente)
        {
            var clienteAtualizado = await _clienteManager.UpdateClienteAsync(cliente);
            if (clienteAtualizado == null)
                return NotFound();

            return Ok(clienteAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteManager.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}
