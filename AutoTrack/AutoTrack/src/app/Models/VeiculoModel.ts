import { Cliente } from "./ClienteModel";
import { Servico } from "./ServicoMode";

export class Veiculo {
  id?: number;
  carro?: string;
  placa?: string;
  especie?: string;
  combustivel?: string;
  potencia?: string;
  anoFab?: string;
  capacidade?: string;
  anoModelo?: string;
  chassi?: string;
  cor?: string;
  observacao?: string;
  kmAtual?: string;
  proxManutencao?: string;
  proxTrocaFiltro?: string;
  garantia?: string;
  clienteId?: number;
  cliente? : Cliente;
  servicos?: Servico[];

  constructor(init?: Partial<Veiculo>) {
    Object.assign(this, init);
  }
}
