using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.DataContext;
using AutoTrackApi.Interface;
using AutoTrackApi.Model;
using Microsoft.EntityFrameworkCore;

namespace AutoTrackApi.Persistencia
{
    public class MontagemPersist : IMontagemPersist
    {
    private readonly ConnectionContext _context;

        public MontagemPersist(ConnectionContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Montagem>> GetMontagemsByData(string dataMont)
        {
             var montagens = await _context.montagens
                .AsNoTracking() // Evita rastreamento de mudanças para melhorar a performance
                .Include(v => v.veiculo) // Inclui apenas o veículo relacionado ao serviço
                .Where(m => m.data == dataMont) // Filtra pelos serviços com a data especificada
                .ToListAsync(); // Converte o resultado para uma lista

            return montagens;
        }
    }
}