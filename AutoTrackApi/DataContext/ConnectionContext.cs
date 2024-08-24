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
    }
}
