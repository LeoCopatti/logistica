using Core.Domain.Base;
using Core.Domain.Empresa;

namespace Core.Domain.Entregas
{
    public class ValorEntregadorEmpresa : Entidade
    {
        public Entregador Entregador { get; set; }

        public EmpresaContratante EmpresaContratante { get; set; }

        public decimal ValorEntrega { get; set; }
    }
}
