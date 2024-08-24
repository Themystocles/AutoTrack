using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrackApi.Model.DTOs
{
    public class ServicoDto
    {
    public int Id { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
    public string Peca_Servico { get; set; }
    public string ValorUni { get; set; }
    public string ValorTot { get; set; }
    public string FormaPag { get; set; }
    public string Mecanico { get; set; }
    public string Saida { get; set; }
    public DateTime DataServico { get; set; }
    
    public List<OrcamentoDto> Orcamentos { get; set; }
    }
}