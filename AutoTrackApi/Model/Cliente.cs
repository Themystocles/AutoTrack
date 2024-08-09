using AutoTrackApi.Model;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string InsEstadual { get; set; }
    public string InsMunicipal { get; set; }
    public string Telefone { get; set; }
    public string InsTelefone2 { get; set; }
    public string Endereco { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Cep { get; set; }
    public string Uf { get; set; }
   public List<Veiculo> Veiculos { get; set; } 
  
}
