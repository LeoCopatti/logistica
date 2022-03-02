using Core.Shared.ModelViews.Contratantes;
using Manager.Interfaces.Managers.Contratantes;
using Manager.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjetoDistribuidora.Controllers.Contratantes
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasContratantesController : ControllerBase
    {
        private readonly IEmpresaContratanteManager _manager;
        private readonly IExportExcelService _excelService;

        public EmpresasContratantesController(IEmpresaContratanteManager manager, IExportExcelService excelService)
        {
            _manager = manager;
            _excelService = excelService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _manager.GetEmpresasContratantesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _manager.GetEmpresaContratanteAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(NovaEmpresaContratante novaEmpresaContratante)
        {
            var empresaContratanteInserida = await _manager.InsertEmpresaContratanteAsync(novaEmpresaContratante);
            return CreatedAtAction(nameof(Get), new { id = empresaContratanteInserida.Id }, empresaContratanteInserida);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlteraEmpresaContratante alteraEmpresaContratante)
        {
            var empresaContratanteAtualizado = await _manager.UpdateEmpresaContratanteAsync(alteraEmpresaContratante);
            if (empresaContratanteAtualizado == null)
                return NotFound();

            return Ok(empresaContratanteAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manager.DeleteEmpresaContratanteAsync(id);
            return NoContent();
        }

    }
}