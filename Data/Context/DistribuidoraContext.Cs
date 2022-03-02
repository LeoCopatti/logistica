using Core.Domain;
using Core.Domain.Empresa;
using Core.Domain.Entregas;
using Core.Domain.Exemplos;
using Core.Domain.User;
using Data.Configuration;
using Data.Configuration.Entregas;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DistribuidoraContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<TelefoneExemplo> TelefonesExemplo { get; set; }

        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Especialidade> Especialidades { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Funcao> Funcoes { get; set; }

        public DbSet<Documento> Documentos { get; set; }

        public DbSet<Entrega> Entregas { get; set; }

        public DbSet<Entregador> Entregadores { get; set; }

        public DbSet<Telefone> Telefones { get; set; }

        public DbSet<ValorEntregadorEmpresa> ValoresEntregadorEmpresa { get; set; }

        public DbSet<EmpresaContratante> EmpresasContratantes { get; set; }

        public DistribuidoraContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new TelefoneExemploConfiguration());
            modelBuilder.ApplyConfiguration(new EntregadorConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }
    }
}
