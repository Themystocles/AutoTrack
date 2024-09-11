using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.Model;

namespace AutoTrackApi.Interface
{
    public interface IRelatorioFinanceiroPersist
    {
        Task<decimal> GetValorTotalPeriodo (DateTime dataInicio, DateTime dataFim);
        Task<decimal> GetValorTotalPix (DateTime dataInicio, DateTime dataFim);
        Task<decimal> GetValorTotalDinheiro (DateTime dataInicio, DateTime dataFim);
        Task<decimal> GetValorTotalDebito (DateTime dataInicio, DateTime dataFim);
        Task<decimal> GetValorTotaCredito (DateTime dataInicio, DateTime dataFim);

        //Não Pagos

        Task<decimal> GetValorTotalPeriodoNP (DateTime dataInicio, DateTime dataFim);
        Task<decimal> GetValorTotalPixNP (DateTime dataInicio, DateTime dataFim);
        Task<decimal> GetValorTotalDinheiroNP (DateTime dataInicio, DateTime dataFim);
        Task<decimal> GetValorTotalDebitoNP(DateTime dataInicio, DateTime dataFim);
        Task<decimal> GetValorTotaCreditoNP (DateTime dataInicio, DateTime dataFim);

        //montagem

          Task<decimal> GetMontValorTotalPeriodo (DateTime dataInicio, DateTime dataFim);
        Task<decimal> GetMonValorTotalPix (DateTime dataInicio, DateTime dataFim);
        Task<decimal> GetMonValorTotalDinheiro (DateTime dataInicio, DateTime dataFim);
        Task<decimal> GetMonValorTotalDebito (DateTime dataInicio, DateTime dataFim);
        Task<decimal> GetMonValorTotaCredito (DateTime dataInicio, DateTime dataFim);

        //Não Pagos

        Task<decimal> GetMonValorTotalPeriodoNP (DateTime dataInicio, DateTime dataFim);
        Task<decimal> GetMonValorTotalPixNP (DateTime dataInicio, DateTime dataFim);
        Task<decimal> GetMonValorTotalDinheiroNP (DateTime dataInicio, DateTime dataFim);
        Task<decimal> GetMonValorTotalDebitoNP(DateTime dataInicio, DateTime dataFim);
        Task<decimal> GetMonValorTotaCreditoNP (DateTime dataInicio, DateTime dataFim);


    }
}