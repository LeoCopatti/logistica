﻿using Core.Domain.Base;
using System.Collections.Generic;

namespace Core.Domain.User
{
    public class Usuario
    {
        public string Login { get; set; }

        public string Senha { get; set; }

        public ICollection<Funcao> Funcoes { get; set; }

        public Usuario()
        {
            Funcoes = new HashSet<Funcao>();
        }
    }
}
