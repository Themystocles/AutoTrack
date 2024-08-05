import { Veiculo } from "./VeiculoModel";

export class Cliente {
    id?: number;
    nome?: string;
    cpf?: string;
    insEstadual?: string;
    insMunicipal?: string;
    telefone?: string;
    insTelefone2?: string;
    endereco?: string;
    bairro?: string;
    cidade?: string;
    cep?: string;
    uf?: string;
    veiculos?: Veiculo[];
  
    constructor(init?: Partial<Cliente>) {
      Object.assign(this, init);
    }
  }
  