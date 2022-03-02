using Core.Domain.Entregas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration.Entregas
{
    public class EntregadorConfiguration : IEntityTypeConfiguration<Entregador>
    {
        public void Configure(EntityTypeBuilder<Entregador> builder)
        {
            builder.HasOne(p => p.Endereco).WithOne(p => p.Entregador).HasForeignKey<Endereco>(p => p.EntregadorId);
        }
    }
}
