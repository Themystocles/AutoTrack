using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTrackApi.Model.Entities;

namespace AutoTrackApi.Model.DTOs
{
    public class OrcamentoDto
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public string NomeServico { get; set; }
        public string? Produto { get; set; }
        public decimal ValorParcial { get; set; }        
        public decimal ValorTotal { get; set; }   
        public int? ServicoId { get; set; }
        public int? EstoqueId { get; set; }
        public int? MontagemId { get; set; }
       
    }
}