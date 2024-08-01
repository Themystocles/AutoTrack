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

        public async Task<IEnumerable<T>> GetAll<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<Cliente> GetClienteByCpf(string cpf)
        {
            return await _context.Clientes
            .Include(c => c.Veiculos)
            .ThenInclude(V => V.servicos)
            .FirstOrDefaultAsync(c => c.Cpf == cpf);
        }

        public Task<Cliente> GetClienteBynumeroTel(string telefone)
        {
            throw new NotImplementedException();
        }
    }
}
