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

        public async Task<int> GetCountMontagensNaoPagos()
        {
            return await _context.montagens.CountAsync(m => !m.pago);
        }

        public async Task<IEnumerable<Montagem>> GetMontagemByDataAlerta(DateTime dataalertamont)
        {
            var montagem = await _context.montagens
                .AsNoTracking() // Evita rastreamento de mudanças para melhorar a performance
                .Include(v => v.veiculo)// Inclui apenas o veículo relacionado ao serviço
                .ThenInclude(c => c.Cliente)
                .Include(o => o.orcamentos) 
                .Where(m => m.dataalerta.HasValue && m.dataalerta.Value.Date == dataalertamont.Date  && m.pago == false) // Filtra pelos serviços com a data especificada
                .ToListAsync(); // Converte o resultado para uma lista

            return montagem;
        }

        public async Task<Montagem> GetMontagemById(int idMontagem)
        {
            return await _context.montagens
            .Include(m => m.orcamentos)
            .ThenInclude(o => o.OrcamentoFuncionarios)
             .ThenInclude(f => f.Funcionario)
            .FirstOrDefaultAsync(M => M.Id == idMontagem );
        }

        public async Task<IEnumerable<Montagem>> GetMontagemsByData(DateTime dataMont)
        {
             var montagens = await _context.montagens
                .AsNoTracking() // Evita rastreamento de mudanças para melhorar a performance
                .Include(v => v.veiculo)
                .Include(o => o.orcamentos)  // Inclui apenas o veículo relacionado ao serviço
                .Where(m => m.data.Date == dataMont.Date) // Filtra pelos serviços com a data especificada
                .ToListAsync(); // Converte o resultado para uma lista

            return montagens;
        }

        public async Task<Montagem> GetMontagensByNFEVenda(string NFEVenda)
        {
            var montagens = await _context.montagens
                .AsNoTracking() // Evita rastreamento de mudanças para melhorar a performance
                .Include(v => v.veiculo)// Inclui apenas o veículo relacionado ao serviço
                .Include(o => o.orcamentos) 
                .FirstOrDefaultAsync(m => m.NumeroNFEquipamento.ToLower().Contains(NFEVenda.ToLower())) ;
                 // Converte o resultado para uma lista

            return montagens;
            
        }

        public async Task<IEnumerable<Montagem>> GetMontagensNaoPagos()
        {
            var montagem = await _context.montagens
           .AsNoTracking()
           .Include(v => v.veiculo)
           .ThenInclude(c => c.Cliente)
           .Include(o => o.orcamentos)
           .Where(s => !s.pago)
           .ToListAsync();

           return montagem;
        }
        

      
    }
}