using Core.Domain.Base;

namespace Core.Domain.Entregas
{
    public class Endereco : Entidade
    {
        public int CEP { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public int EntregadorId { get; set; }

        public Entregador Entregador { get; set; }
    }
}