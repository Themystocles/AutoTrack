using Microsoft.EntityFrameworkCore;
using AutoTrackApi.Model;

namespace AutoTrackApi.DataContext
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

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
