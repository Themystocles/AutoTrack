using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrackApi.Model
{
    public class Veiculo
{
    public int Id { get; set; }
    public string Carro { get; set; }
    public string? Placa { get; set; }
    public string Especie { get; set; }
    public string Combustivel { get; set; }
    public string Potencia { get; set; }
    public string AnoFab { get; set; }
    public string Capacidade { get; set; }
    public string AnoModelo { get; set; }
    public string Chassi { get; set; }
    public string Cor { get; set; }
    public string Observacao { get; set; }
   
   
    public string Garantia { get; set; }
    public string Renavam { get; set; }
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }   
    public List<Servico>? servicos { get; set; } 
    public List<Montagem>? montagens { get; set; } 
    
}
}