using System.Collections.Generic;

namespace Core.Shared.ModelViews
{
    public class UsuarioView
    {
        public string Login { get; set; }

        public ICollection<FuncaoView> Funcoes { get; set; }
    }
}
