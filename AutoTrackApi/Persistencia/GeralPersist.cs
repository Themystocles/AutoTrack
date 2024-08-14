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
