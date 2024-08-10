import { Cliente } from "./ClienteModel";
import { Montagem } from "./MontagemModel";
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
  renavam?: string;
  clienteId?: number;
  cliente? : Cliente;
  servicos?: Servico[];
  montagens?: Montagem[];

  constructor(init?: Partial<Veiculo>) {
    Object.assign(this, init);
  }
}
