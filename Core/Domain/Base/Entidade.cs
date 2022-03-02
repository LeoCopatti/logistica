﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Base
{
    public class Entidade
    {
        public int Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime UltimaAtualizacao { get; set; }

    }
}
