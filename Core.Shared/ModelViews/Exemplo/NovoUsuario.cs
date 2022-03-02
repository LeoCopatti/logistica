using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Shared.ModelViews
{
    public class NovoUsuario
    {
        public string Login { get; set; }

        public string Senha { get; set; }

        public ICollection<ReferenciaFuncao> Funcoes { get; set; }
    }
}
