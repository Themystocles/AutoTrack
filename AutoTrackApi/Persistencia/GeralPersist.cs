using System.Collections.Generic;
using System.Threading.Tasks;
using AutoTrackApi.DataContext;
using AutoTrackApi.Interface;
using Microsoft.EntityFrameworkCore;

namespace AutoTrackApi.Persistencia
{
    public class GeralPersist : IGeralPersist
    {
        private readonly ConnectionContext _context;

        public GeralPersist(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar<T>(T entity) where T : class
        {
              if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "A entidade não pode ser nula.");
        }

        // Marca a entidade para remoção no contexto do EF Core
        _context.Set<T>().Remove(entity);

        // Salva as alterações no banco de dados de forma assíncrona
        await _context.SaveChangesAsync();
        }

        public async Task Editar<T>(T entity) where T : class
        {
            _context.Update(entity);
             await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task<Cliente> GetClienteBynumeroTel(string telefone)
        {
            throw new NotImplementedException();
        }
    }
}
