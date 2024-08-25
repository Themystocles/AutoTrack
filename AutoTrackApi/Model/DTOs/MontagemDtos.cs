using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrackApi.Model.DTOs
{
    public class MontagemDtos
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string GeracaoInstaladores { get; set; }
        public decimal RedutorValor { get; set; }
        public string NumeroSerie { get; set; }
        public string FormaPagamento { get; set; }
        public string MarcaCilindro { get; set; }
        public int NumeroCilindro { get; set; }
        public decimal Quilo { get; set; }
        public decimal Litro { get; set; }
        public int AnoFab { get; set; }
        public int DocumentacaoAno { get; set; }
        public int AnoReteste { get; set; }
        public string Requalificadora { get; set; }
        public string NumeroNFEquipamento { get; set; }
        public string NumeroOrdemRequalificacao { get; set; }
        public string NumeroLaudoMontagem { get; set; }
        public string MarcaValvula { get; set; }
        public string NumeroNFServicoMontagem { get; set; }
        public string NumeroValvula { get; set; }
        public string Selo { get; set; }
        public decimal Orcamento { get; set; }
        public int QuantPecaServico { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public bool KitDaLoja { get; set; }
        public List<OrcamentoDto> Orcamentos { get; set; }
    }
}