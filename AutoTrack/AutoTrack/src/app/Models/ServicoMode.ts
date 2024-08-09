import { Veiculo } from "./VeiculoModel";

export class Servico {
    id?: number;
    descricao?: string;
    quantidade?: number;
    peca_Servico?: string;
    valorUni?: string;
    valorTot?: string;
    formaPag?: string;
    mecanico?: string;
    saida?: string;
    veiculoId?: number;
    dataServ?: string;
    veiculo?: Veiculo;
    constructor(init?: Partial<Servico>) {
      Object.assign(this, init);
    }
  }
  