using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutoTrackApi.Model
{
    public class Servico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        
        public string FormaPag { get; set; }
        public decimal? Totalorcamento { get; set; }

        public bool pago { get; set; }

        public DateTime? dataalerta { get; set; }
        public string Mecanico { get; set; }
        public string Observacao { get; set; }
        public DateTime DataServico { get; set; } = DateTime.Now;
        public int VeiculoId { get; set; }
        public Veiculo? veiculo { get; set; }
         public List<Orcamento>? orcamentos { get; set; } 

         //Quando for requalificação: {
         public string? Requalificacao { get; set; }
         public string? MarcaCilindro { get; set; }
         public string? NumeroCilindro { get; set; }
         public string? Requalificadora { get; set; }
         public string? Ordem { get; set; }
         public string? NotaDeServico { get; set; }
         public string? Laudo { get; set; }
         public string? NotaDaValvula { get; set; }
         public string? MarcaValvula { get; set; }
         public string? NumeroValvula { get; set; }

         //}
        
        
       



    }
}