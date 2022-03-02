using Core.Domain.Base;

namespace Core.Domain.Entregas
{
    public class Telefone : Entidade
    {
        public int DDD { get; set; }

        public string NumeroTelefone { get; set; }
    }
}