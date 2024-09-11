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
    public class RelatorioFinanceiroPersist : IRelatorioFinanceiroPersist
    {
          private readonly ConnectionContext _context;

        public RelatorioFinanceiroPersist(ConnectionContext context)
        {
            _context = context;
        }

        
        public async Task<decimal> GetMontValorTotalPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            var Montagem = await _context.montagens
            .AsNoTracking()
            .Where(m => m.data.Date >= dataInicio.Date && m.data.Date <= dataFim.Date && m.pago)
            .ToListAsync();

            
            return Montagem.Sum(s => s.ValorTotal ?? 0);
        }

        public async Task<decimal> GetMonValorTotaCredito(DateTime dataInicio, DateTime dataFim)
        {
    var montagem = await _context.montagens
        .AsNoTracking()
        .Where(s => s.data.Date >= dataInicio.Date 
                    && s.data.Date <= dataFim.Date 
                    && s.FormaPagamento == "Crédito"
                    && s.pago)
        .ToListAsync();
        

    return montagem.Sum(s => s.ValorTotal ?? 0) ;
    
}

        public async Task<decimal> GetMonValorTotaCreditoNP(DateTime dataInicio, DateTime dataFim)
          {
    var montagem = await _context.montagens
        .AsNoTracking()
        .Where(s => s.data.Date >= dataInicio.Date 
                    && s.data.Date <= dataFim.Date 
                    && s.FormaPagamento == "Crédito"
                    && !s.pago)
        .ToListAsync();
        

    return montagem.Sum(s => s.ValorTotal ?? 0) ;
    
}

        public async Task<decimal> GetMonValorTotalDebito(DateTime dataInicio, DateTime dataFim)
         {
            var montagem = await _context.montagens
        .AsNoTracking()
        .Where(s => s.data.Date >= dataInicio.Date 
                    && s.data.Date <= dataFim.Date 
                    && s.FormaPagamento == "Débito"
                    && s.pago)
        .ToListAsync();

    return montagem.Sum(s => s.ValorTotal ?? 0);
}

        public async Task<decimal> GetMonValorTotalDebitoNP(DateTime dataInicio, DateTime dataFim)
             {
            var montagem = await _context.montagens
        .AsNoTracking()
        .Where(s => s.data.Date >= dataInicio.Date 
                    && s.data.Date <= dataFim.Date 
                    && s.FormaPagamento == "Débito"
                    && !s.pago)
        .ToListAsync();

    return montagem.Sum(s => s.ValorTotal ?? 0);
}

        public async Task<decimal> GetMonValorTotalDinheiro(DateTime dataInicio, DateTime dataFim)
         {
            var montagem = await _context.montagens
        .AsNoTracking()
        .Where(s => s.data.Date >= dataInicio.Date 
                    && s.data.Date <= dataFim.Date 
                    && s.FormaPagamento == "Dinheiro"
                    && s.pago)
        .ToListAsync();

    return montagem.Sum(s => s.ValorTotal ?? 0);
}

        public async Task<decimal> GetMonValorTotalDinheiroNP(DateTime dataInicio, DateTime dataFim)
         {
            var montagem = await _context.montagens
        .AsNoTracking()
        .Where(s => s.data.Date >= dataInicio.Date 
                    && s.data.Date <= dataFim.Date 
                    && s.FormaPagamento == "Dinheiro"
                    && !s.pago)
        .ToListAsync();

    return montagem.Sum(s => s.ValorTotal ?? 0);
}

        public async Task<decimal> GetMonValorTotalPeriodoNP(DateTime dataInicio, DateTime dataFim)
          {
            var Montagem = await _context.montagens
            .AsNoTracking()
            .Where(m => m.data.Date >= dataInicio.Date && m.data.Date <= dataFim.Date && !m.pago)
            .ToListAsync();

            
            return Montagem.Sum(s => s.ValorTotal ?? 0);
        }

        public async Task<decimal> GetMonValorTotalPix(DateTime dataInicio, DateTime dataFim)
             {
            var montagem = await _context.montagens
        .AsNoTracking()
        .Where(s => s.data.Date >= dataInicio.Date 
                    && s.data.Date <= dataFim.Date 
                    && s.FormaPagamento == "PIX"
                    && s.pago)
        .ToListAsync();

    return montagem.Sum(s => s.ValorTotal ?? 0);
}

        public async Task<decimal> GetMonValorTotalPixNP(DateTime dataInicio, DateTime dataFim)
        {
                {
            var montagem = await _context.montagens
        .AsNoTracking()
        .Where(s => s.data.Date >= dataInicio.Date 
                    && s.data.Date <= dataFim.Date 
                    && s.FormaPagamento == "PIX"
                    && !s.pago)
        .ToListAsync();

    return montagem.Sum(s => s.ValorTotal ?? 0);
}
        }

        public async Task<decimal> GetValorTotaCredito(DateTime dataInicio, DateTime dataFim)
{
    var servicos = await _context.servicos
        .AsNoTracking()
        .Where(s => s.DataServico.Date >= dataInicio.Date 
                    && s.DataServico.Date <= dataFim.Date 
                    && s.FormaPag == "Crédito"
                    && s.pago)
        .ToListAsync();
        

    return servicos.Sum(s => s.Totalorcamento ?? 0) ;
    
}

        public async Task<decimal> GetValorTotaCreditoNP(DateTime dataInicio, DateTime dataFim)
        {
    var servicos = await _context.servicos
        .AsNoTracking()
        .Where(s => s.DataServico.Date >= dataInicio.Date 
                    && s.DataServico.Date <= dataFim.Date 
                    && s.FormaPag == "Crédito"
                    && !s.pago)
        .ToListAsync();
        

    return servicos.Sum(s => s.Totalorcamento ?? 0) ;
    
}

        public async Task<decimal> GetValorTotalDebito(DateTime dataInicio, DateTime dataFim)
        {
            var servicos = await _context.montagens
        .AsNoTracking()
        .Where(s => s.data.Date >= dataInicio.Date 
                    && s.data.Date <= dataFim.Date 
                    && s.FormaPagamento == "Débito"
                    && s.pago)
        .ToListAsync();

    return servicos.Sum(s => s.ValorTotal ?? 0);
}

        public async Task<decimal> GetValorTotalDebitoNP(DateTime dataInicio, DateTime dataFim)
         {
            var servicos = await _context.montagens
        .AsNoTracking()
        .Where(s => s.data.Date >= dataInicio.Date 
                    && s.data.Date <= dataFim.Date 
                    && s.FormaPagamento == "Débito"
                    && !s.pago)
        .ToListAsync();

    return servicos.Sum(s => s.ValorTotal ?? 0);
}

        public async Task<decimal> GetValorTotalDinheiro(DateTime dataInicio, DateTime dataFim)
            {
            var servicos = await _context.servicos
        .AsNoTracking()
        .Where(s => s.DataServico.Date >= dataInicio.Date 
                    && s.DataServico.Date <= dataFim.Date 
                    && s.FormaPag == "Dinheiro"
                    && s.pago)
        .ToListAsync();

    return servicos.Sum(s => s.Totalorcamento ?? 0);
}

        public async Task<decimal> GetValorTotalDinheiroNP(DateTime dataInicio, DateTime dataFim)
        {
            var servicos = await _context.servicos
        .AsNoTracking()
        .Where(s => s.DataServico.Date >= dataInicio.Date 
                    && s.DataServico.Date <= dataFim.Date 
                    && s.FormaPag == "Dinheiro"
                    && !s.pago)
        .ToListAsync();

    return servicos.Sum(s => s.Totalorcamento ?? 0);
}

        public  async Task<decimal> GetValorTotalPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            var servicos = await _context.servicos
            .AsNoTracking()
            .Where(s => s.DataServico.Date >= dataInicio.Date && s.DataServico.Date <= dataFim.Date && s.pago)
            .ToListAsync();

            
            return servicos.Sum(s => s.Totalorcamento ?? 0);
        }

        public async Task<decimal> GetValorTotalPeriodoNP(DateTime dataInicio, DateTime dataFim)
         {
            var servicos = await _context.servicos
            .AsNoTracking()
            .Where(s => s.DataServico.Date >= dataInicio.Date && s.DataServico.Date <= dataFim.Date && !s.pago)
            .ToListAsync();

            
            return servicos.Sum(s => s.Totalorcamento ?? 0);
        }

        public async Task<decimal> GetValorTotalPix(DateTime dataInicio, DateTime dataFim)
           {
            var servicos = await _context.servicos
        .AsNoTracking()
        .Where(s => s.DataServico.Date >= dataInicio.Date 
                    && s.DataServico.Date <= dataFim.Date 
                    && s.FormaPag == "PIX"
                    && s.pago)
        .ToListAsync();

    return servicos.Sum(s => s.Totalorcamento ?? 0);
}

        public async Task<decimal> GetValorTotalPixNP(DateTime dataInicio, DateTime dataFim)
       {
            var servicos = await _context.servicos
        .AsNoTracking()
        .Where(s => s.DataServico.Date >= dataInicio.Date 
                    && s.DataServico.Date <= dataFim.Date 
                    && s.FormaPag == "PIX"
                    && !s.pago)
        .ToListAsync();

    return servicos.Sum(s => s.Totalorcamento ?? 0);
}
    }
}