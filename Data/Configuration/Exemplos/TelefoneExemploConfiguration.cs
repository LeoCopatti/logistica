using Core.Domain.Exemplos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Context
{
    internal class TelefoneExemploConfiguration : IEntityTypeConfiguration<TelefoneExemplo>
    {
        public void Configure(EntityTypeBuilder<TelefoneExemplo> builder)
        {
            builder.HasKey(p => new { p.ClienteId, p.NumeroTelefone });
        }
    }
}