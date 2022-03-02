using Core.Shared.ModelViews.Excel;
using Manager.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDistribuidora.Controllers.Excel
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IExportExcelService _service;

        public ExcelController(IExportExcelService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(GeracaoExcelParams parameters)
        {
            var excel = await _service.GeraExcelAsync(parameters);

            return File(excel.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Relatorio_Entregadores.xlsx");
        }

    }
}
