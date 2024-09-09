using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrack.Migrations;
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

        public async Task<int> GetCountServicosNaoPagos()
        {
            return await _context.servicos.CountAsync(s => !s.pago);
        }

        public async Task<Servico> GetServicoById(int idServico)
        {
            return await _context.servicos
             .Include(s => s.orcamentos) // Inclui os orçamentos relacionados
            .FirstOrDefaultAsync(S => S.Id == idServico);
        }

        public async Task<IEnumerable<Servico>> GetServicosByAlertDate(DateTime dataalertserv)
        {
            var servicos = await _context.servicos
                .AsNoTracking() // Evita rastreamento de mudanças para melhorar a performance
                .Include(v => v.veiculo)// Inclui apenas o veículo relacionado ao serviço
                .ThenInclude(c => c.Cliente)
                .Include(o => o.orcamentos) 
                .Where(s => s.dataalerta.HasValue && s.dataalerta.Value.Date == dataalertserv.Date  && s.pago == false) // Filtra pelos serviços com a data especificada
                .ToListAsync(); // Converte o resultado para uma lista

            return servicos;
           
        }

        public async Task<IEnumerable<Servico>> GetServicosByDate(DateTime dataserv)
        {
            var servicos = await _context.servicos
                .AsNoTracking() // Evita rastreamento de mudanças para melhorar a performance
                .Include(v => v.veiculo)// Inclui apenas o veículo relacionado ao serviço
                .Include(o => o.orcamentos) 
                .Where(s => s.DataServico.Date == dataserv.Date) // Filtra pelos serviços com a data especificada
                .ToListAsync(); // Converte o resultado para uma lista

            return servicos;
        }

        public async Task<IEnumerable<Servico>> GetServicosByTipo(string TipoServ)
        {
            var servicos = await _context.servicos
                .AsNoTracking() // Evita rastreamento de mudanças para melhorar a performance
                .Include(v => v.veiculo)// Inclui apenas o veículo relacionado ao serviço
                .Include(o => o.orcamentos) 
                .Where(s => s.Requalificacao == TipoServ) // Filtra pelos serviços com a data especificada
                .ToListAsync(); // Converte o resultado para uma lista

            return servicos;
        }

        public async Task<IEnumerable<Servico>> GetServicosNaoPagos()
        {
           var serviços = await _context.servicos
           .AsNoTracking()
           .Include(v => v.veiculo)
           .ThenInclude(c => c.Cliente)
           .Include(o => o.orcamentos)
           .Where(s => !s.pago)
           .ToListAsync();

           return serviços;
           
        }
    }
}
