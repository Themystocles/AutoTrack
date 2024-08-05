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
  
    constructor(init?: Partial<Servico>) {
      Object.assign(this, init);
    }
  }
  