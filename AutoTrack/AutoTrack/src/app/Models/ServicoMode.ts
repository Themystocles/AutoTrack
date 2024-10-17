import { Orcamento } from "./OrcamentoModel";
import { Veiculo } from "./VeiculoModel";

export class Servico {
  id?: number;
  descricao?: string;
  formaPag?: string;
  totalorcamento?: number;
  pago?: boolean;
  dataalerta?: string;
  mecanico?: string;
  observacao?: string;
  status?: string;
  veiculoId?: number;
  dataServico?: string; // Nome atualizado para corresponder à API
  veiculo?: Veiculo;
  orcamentos?: Orcamento[];

  //Se for requalificação{

  requalificacao?: string;
  marcaCilindro?: string;
  numeroCilindro?: string;
  requalificadora?: string;
  ordem?: string;
  notaDeServico?: string;
  laudo?: string;
  notaDaValvula?: string;
  marcaValvula?: string;
  numeroValvula?: string;

  //}
  showDetails?: boolean;

  constructor(init?: Partial<Servico>) {
    Object.assign(this, init);
  }
}
