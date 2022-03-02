using Core.Domain.Entregas;

namespace Core.Domain.Excel
{
    public class TotalizadorExcel
    {
        public Entregador Entregador { get; set; }

        public int TotalEntregas { get; set; }

        public decimal TotalValoresEntregas { get; set; }
    }
}
