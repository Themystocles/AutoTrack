import { Orcamento } from "./OrcamentoModel";
import { Veiculo } from "./VeiculoModel";

export class Servico {
    id?: number;
    descricao?: string;
    formaPag?: string;
    mecanico?: string;
    observacao?: string;
    veiculoId?: number;
    dataServico?: string; // Nome atualizado para corresponder à API
    veiculo?: Veiculo;
    orcamentos?: Orcamento[];
    
    
    constructor(init?: Partial<Servico>) {
      Object.assign(this, init);
    }
}
