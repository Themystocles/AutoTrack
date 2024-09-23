using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoTrack.Migrations;
using AutoTrackApi.DataContext;
using AutoTrackApi.Interface;
using AutoTrackApi.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoTrackApi.Persistencia
{
    public class OrcamentoFuncionarioPersist : IOrcamentoFuncionarioPersist
    {
        private readonly ConnectionContext _context;

        public OrcamentoFuncionarioPersist(ConnectionContext context)
        {
            _context = context;
        }
    
  

public async Task<IEnumerable<FuncionarioOrcamentosDTO>> ObterFuncionarioeOrcamentosAtrelados(DateTime dataInicio, DateTime dataFim)
{
    var resultado = await _context.OrcamentoFuncionarios
        .AsNoTracking()
        .Include(f => f.Funcionario)
        .Include(o => o.Orcamento)
        .Where(o => o.Orcamento.DataOrc.Date >= dataInicio.Date && o.Orcamento.DataOrc.Date <= dataFim.Date) // Filtro de data
        .GroupBy(f => new
        {
            f.Funcionario.Nome,
            f.Funcionario.Cpf,
            
        })
        .Select(g => new FuncionarioOrcamentosDTO
        {
            NomeFuncionario = g.Key.Nome,
            CpfFuncionario = g.Key.Cpf,
            Orcamentos = g.Select(o => new OrcamentoFuncionarioDTO
            {
                NomeOrcamento = o.Orcamento.NomeServico,
                Quantidade = o.Orcamento.Quantidade,
                valorParcial = o.Orcamento.ValorParcial,
                ValorTotal = o.Orcamento.ValorTotal,
                DataOrc = o.Orcamento.DataOrc
                
            }).ToList()
        })
        .ToListAsync();

    return resultado;
}

 

} 
}
     
    
