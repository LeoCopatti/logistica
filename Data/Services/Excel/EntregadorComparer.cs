using Core.Domain.Entregas;
using System.Collections.Generic;

namespace Data.Services.Excel
{
    public class EntregadorComparer : IEqualityComparer<Entregador>
    {
        public bool Equals(Entregador a, Entregador b)
        {
            return a.Id == b.Id;
        }

        public int GetHashCode(Entregador a)
        {
            return a.Id.GetHashCode();
        }
    }
}
