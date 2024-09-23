using Microsoft.EntityFrameworkCore;
using AutoTrackApi.Model;
using AutoTrackApi.Model.Entities;
using AutoTrack.Migrations;

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
        public DbSet<Funcionarios> funcionarios { get; set; }
        public DbSet<OrcamentoFuncionario> OrcamentoFuncionarios { get; set; }
        

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
                // Usar a string de conexão do appsettings.jsond
                optionsBuilder.UseSqlite("Data Source=AutoTrack.db");
                
            }
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<OrcamentoFuncionario>()
            .HasKey(of => new { of.OrcamentoId, of.FuncionarioId });

        modelBuilder.Entity<OrcamentoFuncionario>()
            .HasOne(of => of.Orcamento)
            .WithMany(o => o.OrcamentoFuncionarios) // Usa OrcamentoFuncionarios na classe Orcamento
            .HasForeignKey(of => of.OrcamentoId);

        modelBuilder.Entity<OrcamentoFuncionario>()
            .HasOne(of => of.Funcionario)
            .WithMany(f => f.OrcamentoFuncionarios) // Usa OrcamentoFuncionarios na classe Funcionarios
            .HasForeignKey(of => of.FuncionarioId);

          
        }
    }
}
