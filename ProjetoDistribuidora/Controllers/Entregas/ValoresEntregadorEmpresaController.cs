using Core.Shared.ModelViews.Entregas;
using Manager.Interfaces.Managers.Entregas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Threading.Tasks;

namespace ProjetoDistribuidora.Controllers.Entregas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValoresEntregadorEmpresaController : ControllerBase
    {
        private readonly IValorEntregadorEmpresaManager _manager;

        public ValoresEntregadorEmpresaController(IValorEntregadorEmpresaManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _manager.GetValoresEntregadorEmpresaAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _manager.GetValorEntregadorEmpresaAsync(id));
        }

        [HttpGet]
        [Route("FindByEntregador")]
        public async Task<IActionResult> FindByEntregadorAsync(int entregadorId)
        {
            return Ok(await _manager.GetValoresEntregadorEmpresaByEntregadorAsync(entregadorId));
        }

        [HttpGet]
        [Route("FindByEntregadorEmpresa")]
        public async Task<IActionResult> FindByEntregadorEmpresaAsync(int entregadorId, int empresaId)
        {
            return Ok(await _manager.GetValoresEntregadorEmpresaByEmpresaEntregadorAsync(entregadorId, empresaId));
        }

        [HttpPost]
        public async Task<IActionResult> Post(NovoValorEntregadorEmpresa novoValorEntregadorEmpresa)
        {
            var valorEntregadorEmpresaInserido = await _manager.InsertValorEntregadorEmpresaAsync(novoValorEntregadorEmpresa);
            return CreatedAtAction(nameof(Get), new { id = valorEntregadorEmpresaInserido.Id }, valorEntregadorEmpresaInserido);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlteraValorEntregadorEmpresa alteraValorEntregadorEmpresa)
        {
            var valorEntregadorEmpresaAtualizado = await _manager.UpdateValorEntregadorEmpresaAsync(alteraValorEntregadorEmpresa);
            if (valorEntregadorEmpresaAtualizado == null)
                return NotFound();

            return Ok(valorEntregadorEmpresaAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manager.DeleteValorEntregadorEmpresaAsync(id);
            return NoContent();
        }
    }
}
