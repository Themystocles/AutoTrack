import { Orcamento } from "./OrcamentoModel";
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
    dataServico?: string; // Nome atualizado para corresponder à API
    veiculo?: Veiculo;
    orcamentos?: Orcamento[];
    
    
    constructor(init?: Partial<Servico>) {
      Object.assign(this, init);
    }
}
