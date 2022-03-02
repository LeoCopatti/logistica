using Core.Domain.Base;

namespace Core.Domain.Entregas
{
    public class Documento : Entidade
    {
        public byte[] ImagemDocumento { get; set; }
    }
}