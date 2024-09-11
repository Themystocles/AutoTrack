using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrack.Migrations;

namespace AutoTrackApi.Model.Entities
{
    public class Orcamento
    {
        public int Id { get; set; }
        
        public DateTime DataOrc { get; set; } = DateTime.Now;
        public int Quantidade { get; set; }
        public string NomeServico { get; set; }
        public string? Produto { get; set; }
        public decimal ValorParcial { get; set; }        
        public decimal ValorTotal { get; set; }   
        public string? Garantia { get; set; }
        public int? ServicoId { get; set; }
        public Servico? Servico { get; set; }
        public int? EstoqueId { get; set; }
        public Estoque? estoque { get; set; }
         public string? KmAtual { get; set; }
        public int? MontagemId { get; set; }
        public Montagem? Montagem { get; set; }
    }
}