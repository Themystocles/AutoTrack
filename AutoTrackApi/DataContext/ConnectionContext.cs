using Microsoft.EntityFrameworkCore;
using AutoTrackApi.Model;
using AutoTrackApi.Model.Entities;

namespace AutoTrackApi.DataContext
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Servico> servicos { get; set; }
        public DbSet<Montagem> montagens { get; set; }
        public DbSet<Orcamento> orcamentos { get; set; }
        public DbSet<Estoque> estoques { get; set; }
        

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
                // Usar a string de conexão do appsettings.json
                optionsBuilder.UseSqlite("Data Source=AutoTrack.db");
                
            }
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           // Configura a propriedade Cpf como opcional e UNIQUE
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Cpf)
                .IsRequired(false); // Permite NULL
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Cpf)
                .IsUnique();

            // Configura a propriedade Placa como opcional e UNIQUE
            modelBuilder.Entity<Veiculo>()
                .Property(v => v.Placa)
                .IsRequired(false); // Permite NULL
            modelBuilder.Entity<Veiculo>()
                .HasIndex(v => v.Placa)
                .IsUnique();

            // Configura a propriedade Chassi como opcional e UNIQUE
            modelBuilder.Entity<Veiculo>()
                .Property(v => v.Chassi)
                .IsRequired(false); // Permite NULL
            modelBuilder.Entity<Veiculo>()
                .HasIndex(v => v.Chassi)
                .IsUnique();
        }
    }
}
