using Core.Domain.Base;
using System.Collections.Generic;

namespace Core.Domain.Entregas
{
    public class Entregador : Entidade
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Cpf { get; set; }

        public string Cnh { get; set; }

        public int EnderecoId { get; set; }

        public Endereco Endereco { get; set; }

        public ICollection<Documento> Documentos { get; set; }

        public ICollection<Telefone> Telefones { get; set; }

    }
}