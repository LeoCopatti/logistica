using Core.Domain.Base;

namespace Core.Domain.Empresa
{
    public class EmpresaContratante : Entidade
    {
        public string RazaoSocial { get; set; }

        public string Cnpj { get; set; }

        public decimal ValorBaseEntrega { get; set; }
    }
}
