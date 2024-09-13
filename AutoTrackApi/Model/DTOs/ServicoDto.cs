using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrackApi.Model.DTOs
{
    public class ServicoDto
    {
    public int Id { get; set; }
    public string? Descricao { get; set; }
    
    public string? FormaPag { get; set; }
    public decimal? Totalorcamento { get; set; }

     public bool pago { get; set; }

    public DateTime? dataalerta { get; set; }
    public string? Mecanico { get; set; }
    public string? Observacao { get; set; }
    public DateTime DataServico { get; set; }
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
    
    public List<OrcamentoDto> Orcamentos { get; set; }
    }
}