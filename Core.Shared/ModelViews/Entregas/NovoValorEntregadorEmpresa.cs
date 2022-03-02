namespace Core.Shared.ModelViews.Entregas
{
    public class NovoValorEntregadorEmpresa
    {
        public ReferenciaEntregador Entregador { get; set; }

        public ReferenciaEmpresaContratante EmpresaContratante { get; set; }

        public decimal ValorEntrega { get; set; }
    }
}
