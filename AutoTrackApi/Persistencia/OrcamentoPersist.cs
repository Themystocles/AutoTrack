using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.DataContext;
using AutoTrackApi.Interface;
using AutoTrackApi.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoTrackApi.Persistencia
{
    public class OrcamentoPersist : IOrcamentoPersist
    {
        private readonly ConnectionContext _context;

        public OrcamentoPersist(ConnectionContext context)
        {
            _context = context;
        }

        public async Task<Orcamento> Delete(int id)
        {
            // Encontrar o orçamento pelo ID
            var orcamento = await _context.orcamentos.FindAsync(id);
            if (orcamento == null)
            {
                return null; // Ou lançar uma exceção, dependendo da sua lógica
            }

            // Remover o orçamento do contexto
            _context.orcamentos.Remove(orcamento);
            await _context.SaveChangesAsync();

            return orcamento; // Retorna o orçamento excluído, se necessário
        }

        public async Task<IEnumerable<Orcamento>> getAllorc()
        {
            return await _context.orcamentos
           .Include(o => o.OrcamentoFuncionarios)

           .ToListAsync();
        }
    }
}