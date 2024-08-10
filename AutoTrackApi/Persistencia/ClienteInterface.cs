using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.DataContext;
using AutoTrackApi.Interface;
using Microsoft.EntityFrameworkCore;

namespace AutoTrackApi.Persistencia
{
    public class ClientePersist : IClientePersist
{
    private readonly ConnectionContext _context;
    public ClientePersist(ConnectionContext context)
        {
            _context = context;
        }
        
    
         public async Task<Cliente> GetClienteByCpf(string cpf)
        {
            return await _context.Clientes
            .Include(c => c.Veiculos)
            .ThenInclude(V => V.servicos)
            .Include(c => c.Veiculos)
            .ThenInclude(m => m.montagens)
            .FirstOrDefaultAsync(c => c.Cpf == cpf);
        }

         public async Task<List<Cliente>> GetClientesByNome(string nome)
    {
        return await _context.Clientes
            .Include(c => c.Veiculos)
            .ThenInclude(v => v.servicos)
             .Include(c => c.Veiculos)
            .ThenInclude(m => m.montagens)
            .Where(c => c.Nome.ToLower().Contains(nome.ToLower()))
            .ToListAsync();
    }
        public async Task<Cliente> GetClienteBynumeroTel(string telefone)
        {
            return await _context.Clientes
            .Include(c => c.Veiculos)
            .ThenInclude(V => V.servicos)
            .Include(c => c.Veiculos)
            .ThenInclude(m => m.montagens)
            .FirstOrDefaultAsync(c => c.Telefone == telefone);
        }

       
    }
}