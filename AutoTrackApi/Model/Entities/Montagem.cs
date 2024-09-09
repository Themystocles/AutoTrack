using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using AutoTrackApi.Model.Entities;
using AutoTrack.Migrations;

namespace AutoTrackApi.Model
{
    [Table("montagens")]
    public class Montagem
    {
        public int Id { get; set; } 
        public DateTime data { get; set; } = DateTime.Now;
        public string? GeracaoInstaladores { get; set; }
        public string? RedutorMarca { get; set; }
        public string? NumeroSerie { get; set; }
        public string? FormaPagamento { get; set; }
        public bool pago { get; set; }
        public string? MarcaCilindro { get; set; }
        public string? NumeroCilindro { get; set; }
        public decimal? Quilo { get; set; }
        public decimal? Litro { get; set; }
        public int? AnoFab { get; set; }
       
        public int? AnoReteste { get; set; }
        public string? Requalificadora { get; set; }
        public string? NumeroNFEquipamento { get; set; }
        public string? NumeroOrdemRequalificacao { get; set; }
        public string? NumeroLaudoMontagem { get; set; }
        public string? MarcaValvula { get; set; }
        public string? NumeroNFServicoMontagem { get; set; }
        public string? NumeroValvula { get; set; }
        public string? Selo { get; set; }
        
        public string? Instaladores { get; set; }
        public decimal? ValorTotal { get; set; }
        public bool? KitDaLoja { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo? veiculo { get; set; }

        public List<Orcamento>? orcamentos { get; set; } 
    }
}