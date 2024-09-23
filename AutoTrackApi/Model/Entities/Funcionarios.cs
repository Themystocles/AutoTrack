using System;
using System.Collections.Generic;

namespace AutoTrackApi.Model.Entities
{
    public class Funcionarios
    {
        public int id { get; set; } 
        public string Nome { get; set; } // Obrigatório
        public string? Cpf { get; set; } // Opcional
        public DateTime? DataAdmissao { get; set; } // Opcional
        public DateTime? DataDemissao { get; set; } // Opcional
        public string? Situacao { get; set; } // Opcional
        public DateTime? DataFerias { get; set; } // Opcional
        public string? Funcao { get; set; } // Opcional
        public DateTime? DataNascimento { get; set; } // Opcional
        public string? Celular1 { get; set; } // Opcional
        public string? Celular2 { get; set; } // Opcional
        public string? Rua { get; set; } // Opcional
        public string? Cep { get; set; } // Opcional
        public string? Cidade { get; set; } // Opcional
        public string? Bairro { get; set; } // Opcional
        public byte[]? Foto { get; set; } // Opcional
        
        public List<OrcamentoFuncionario>? OrcamentoFuncionarios { get; set; }
       
       

        
       
    }
}
