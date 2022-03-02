using System;
using System.Collections.Generic;

namespace Core.Shared.ModelViews.Excel
{
    public class GeracaoExcelParams
    {
        public ICollection<long> EntregadoresId { get; set; }
        public DateTime PeriodoInicial { get; set; }
        public DateTime PeriodoFinal { get; set; }
        public bool GeraTotalizadores { get; set; }
        public bool GeraResumido { get; set; }
        public bool GeraDetalhado { get; set; }
    }
}
