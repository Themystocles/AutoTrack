using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrackApi.Model.Entities
{
    public class OrcamentoFuncionario
    {
        public int OrcamentoId { get; set; }
        public Orcamento Orcamento { get; set; } // Navegação para Orcamento

        public int FuncionarioId { get; set; }
        public Funcionarios Funcionario { get; set; } // Navegação para Funcionarios
    }
    public class FuncionarioOrcamentosDTO
{
    public string NomeFuncionario { get; set; }
    public string CpfFuncionario { get; set; }
    public List<string> NomesOrcamentos { get; set; }
    public List<decimal> ValoresTotais { get; set; }
     public List<OrcamentoFuncionarioDTO> Orcamentos { get; set; }
}
public class OrcamentoFuncionarioDTO
{
    public string NomeOrcamento { get; set; }
    public decimal ValorTotal { get; set; }
    public decimal valorParcial { get; set; }
    public int Quantidade { get; set; }
    public DateTime DataOrc { get; set; }
    
}


}