using System;

namespace Core.Shared.ModelViews.Entregas
{
    public class NovaEntrega
    {
        public DateTime DataEntrega { get; set; }

        public ReferenciaEntregador Entregador { get; set; }

        public ReferenciaEmpresaContratante EmpresaContratante { get; set; }

        public decimal ValorEntrega { get; set; }

        public decimal ValorEntregador { get; set; }
    }
}
