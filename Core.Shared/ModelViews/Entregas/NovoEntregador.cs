using System.Collections.Generic;

namespace Core.Shared.ModelViews.Entregas
{
    public class NovoEntregador
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Cpf { get; set; }

        public string Cnh { get; set; }

        public NovoEndereco Endereco { get; set; }

        public ICollection<NovoDocumento> Documentos { get; set; }

        public ICollection<NovoTelefone> Telefones { get; set; }
    }
}
