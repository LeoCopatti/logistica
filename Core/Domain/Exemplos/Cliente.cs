using System;
using System.Collections.Generic;

namespace Core.Domain.Exemplos
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public char Sexo { get; set; }

        public ICollection<TelefoneExemplo> Telefones { get; set; }

        public string Documento { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? UltimaAtualizacao { get; set; }
    }
}
