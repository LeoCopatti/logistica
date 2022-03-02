using Core.Domain.Base;
using Core.Domain.Empresa;
using System;

namespace Core.Domain.Entregas
{
    public class Entrega : Entidade
    {
        public DateTime DataEntrega { get; set; }

        public Entregador Entregador { get; set; }

        public EmpresaContratante EmpresaContratante { get; set; }

        public decimal ValorEntrega { get; set; }

        public decimal ValorEntregador { get; set; }
    }
}
