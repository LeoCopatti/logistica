using Core.Domain.Entregas;
using System.Collections.Generic;

namespace Data.Services.Excel
{
    public class EntregadorEmpresaComparer : IEqualityComparer<Entrega>
    {
        public bool Equals(Entrega a, Entrega b)
        {
            return a.Entregador.Id == b.Entregador.Id && a.EmpresaContratante.Id == b.EmpresaContratante.Id;
        }

        public int GetHashCode(Entrega a)
        {
            return a.Entregador.Id.GetHashCode() + a.EmpresaContratante.Id.GetHashCode();
        }
    }
}
