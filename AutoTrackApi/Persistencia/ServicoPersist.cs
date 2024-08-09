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
    public class ServicoPersist : IServicoPersist
    {
        private readonly ConnectionContext _context;

        public ServicoPersist(ConnectionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Servico>> GetServicosByDate(string dataserv)
        {
            var servicos = await _context.servicos
                .AsNoTracking() // Evita rastreamento de mudanças para melhorar a performance
                .Include(v => v.veiculo) // Inclui apenas o veículo relacionado ao serviço
                .Where(s => s.DataServico == dataserv) // Filtra pelos serviços com a data especificada
                .ToListAsync(); // Converte o resultado para uma lista

            return servicos;
        }
    }
}
