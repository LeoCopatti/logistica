using Core.Shared.ModelViews.Entregas;
using Manager.Interfaces.Managers.Entregas;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjetoDistribuidora.Controllers.Entregas
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregadoresController : ControllerBase
    {
        private readonly IEntregadorManager _manager;

        public EntregadoresController(IEntregadorManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _manager.GetEntregadoresAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _manager.GetEntregadorAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(NovoEntregador novoEntregador)
        {
            var entregadorInserido = await _manager.InsertEntregadorAsync(novoEntregador);
            return CreatedAtAction(nameof(Get), new { id = entregadorInserido.Id }, entregadorInserido);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlteraEntregador alteraEntregador)
        {
            var entregadorAtualizado = await _manager.UpdateEntregadorAsync(alteraEntregador);
            if (entregadorAtualizado == null)
                return NotFound();

            return Ok(entregadorAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manager.DeleteEntregadorAsync(id);
            return NoContent();
        }
    }
}
