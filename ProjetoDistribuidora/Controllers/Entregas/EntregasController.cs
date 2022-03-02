using Core.Shared.ModelViews.Entregas;
using Manager.Interfaces.Managers.Entregas;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjetoDistribuidora.Controllers.Entregas
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregasController : ControllerBase
    {
        private readonly IEntregaManager _manager;

        public EntregasController(IEntregaManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _manager.GetEntregasAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _manager.GetEntregaAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(NovaEntrega novaEntrega)
        {
            var entregaInserida = await _manager.InsertEntregasAsync(novaEntrega);
            return CreatedAtAction(nameof(Get), new { id = entregaInserida.Id }, entregaInserida);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlteraEntrega alteraEntrega)
        {
            var entregaAtualizada = await _manager.UpdateEntregasAsync(alteraEntrega);
            if (entregaAtualizada == null)
                return NotFound();

            return Ok(entregaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manager.DeleteEntregaAsync(id);
            return NoContent();
        }
    }
}
