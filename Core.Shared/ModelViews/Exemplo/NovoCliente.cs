using System;
using System.Collections.Generic;

namespace Core.Shared.ModelViews
{
    public class NovoCliente
    {
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public char Sexo { get; set; }

        public ICollection<NovoTelefoneExemplo> Telefones { get; set; }

        public string Documento { get; set; }
    }
}
