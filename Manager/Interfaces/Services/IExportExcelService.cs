using Core.Domain.Entregas;
using Core.Shared.ModelViews.Excel;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Manager.Interfaces.Services
{
    public interface IExportExcelService
    {
        Task<ExcelPackage> GeraExcelAsync(GeracaoExcelParams parameters);
        void GeraWorksheetDetalhado(ExcelPackage package, IEnumerable<Entrega> entregas);
        void GeraWorksheetResumido(ExcelPackage package, IEnumerable<Entrega> entregas);
        void GeraWorksheetTotalizadores(ExcelPackage package, IEnumerable<Entrega> entregas);
    }
}
