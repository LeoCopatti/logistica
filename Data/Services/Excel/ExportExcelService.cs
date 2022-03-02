using Core.Domain.Entregas;
using Core.Domain.Excel;
using Core.Shared.ModelViews.Excel;
using Manager.Interfaces.Repositories.Entregas;
using Manager.Interfaces.Services;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Services.Excel
{
    public class ExportExcelService : IExportExcelService
    {
        private readonly IEntregaRepository _entregaRepository;

        public ExportExcelService(IEntregaRepository entregaRepository)
        {
            _entregaRepository = entregaRepository;
        }

        public async Task<ExcelPackage> GeraExcelAsync(GeracaoExcelParams parameters)
        {
            var ids = new List<long>() { 1, 2, 3, 4 };

            var data = await _entregaRepository.GetEntregasAsync();

            var entregadores = data.Where(p => parameters.EntregadoresId.Contains(p.Entregador.Id) && p.DataEntrega >= parameters.PeriodoInicial && p.DataEntrega <= parameters.PeriodoFinal);

            var excel = new ExcelPackage();

            if (parameters.GeraTotalizadores)
                GeraWorksheetTotalizadores(excel, data);

            if (parameters.GeraResumido)
                GeraWorksheetResumido(excel, data);

            if (parameters.GeraDetalhado)
                GeraWorksheetDetalhado(excel, data);

            return excel;
        }

        public void GeraWorksheetTotalizadores(ExcelPackage package, IEnumerable<Entrega> entregas)
        {
            var worksheet = package.Workbook.Worksheets.Add("Totalizadores");

            var entregadores = entregas
                .GroupBy(p => p.Entregador, new EntregadorComparer())
                .Select(g => new { Entregador = $"{g.Key.Nome} {g.Key.Sobrenome}", Count = g.Count(), Sum = g.Sum(p => p.ValorEntregador) })
                .OrderBy(o => o.Entregador);

            worksheet.Cells["A1"].Value = "Entregador";
            worksheet.Cells["B1"].Value = "TotalEntregas";
            worksheet.Cells["C1"].Value = "ValorTotal";

            var row = 2;
            foreach (var entregador in entregadores)
            {
                worksheet.Cells[row, 1].Value = entregador.Entregador;
                worksheet.Cells[row, 2].Value = entregador.Count;
                worksheet.Cells[row, 3].Value = entregador.Sum;

                row++;
            }
        }

        public void GeraWorksheetResumido(ExcelPackage package, IEnumerable<Entrega> entregas)
        {
            var worksheet = package.Workbook.Worksheets.Add("Resumido");

            var entregadores = entregas
                .GroupBy(p => p, new EntregadorEmpresaComparer())
                .Select(g => new { Entregador = $"{g.Key.Entregador.Nome} {g.Key.Entregador.Sobrenome}", EmpresaContratante = g.Key.EmpresaContratante.RazaoSocial, Count = g.Count(), Sum = g.Sum(p => p.ValorEntregador) })
                .OrderBy(o => o.Entregador).ThenBy(o => o.EmpresaContratante);

            worksheet.Cells["A1"].Value = "Entregador";
            worksheet.Cells["B1"].Value = "EmpresaContratante";
            worksheet.Cells["C1"].Value = "TotalEntregas";
            worksheet.Cells["D1"].Value = "ValorTotal";

            var row = 2;
            foreach (var entregador in entregadores)
            {
                worksheet.Cells[row, 1].Value = entregador.Entregador;
                worksheet.Cells[row, 2].Value = entregador.EmpresaContratante;
                worksheet.Cells[row, 3].Value = entregador.Count;
                worksheet.Cells[row, 4].Value = entregador.Sum;

                row++;
            }
        }

        public void GeraWorksheetDetalhado(ExcelPackage package, IEnumerable<Entrega> entregas)
        {
            var worksheet = package.Workbook.Worksheets.Add("Detalhado");

            entregas = entregas.OrderBy(o => o.Entregador.Nome).ThenBy(o => o.Entregador.Sobrenome).ThenBy(o => o.DataEntrega);

            worksheet.Cells["A1"].Value = "Entregador";
            worksheet.Cells["B1"].Value = "EmpresaContratante";
            worksheet.Cells["C1"].Value = "DataEntrega";
            worksheet.Cells["D1"].Value = "ValorEntrega";

            var row = 2;
            foreach (var entregador in entregas)
            {
                worksheet.Cells[row, 1].Value = $"{entregador.Entregador.Nome}  {entregador.Entregador.Sobrenome}";
                worksheet.Cells[row, 2].Value = entregador.EmpresaContratante.RazaoSocial;
                worksheet.Cells[row, 3].Value = entregador.DataEntrega;
                worksheet.Cells[row, 4].Value = entregador.ValorEntregador;

                row++;
            }
        }
    }
}
