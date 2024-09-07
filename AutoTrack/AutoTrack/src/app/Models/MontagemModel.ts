import { Orcamento } from "./OrcamentoModel";
import { Veiculo } from "./VeiculoModel";

export class Montagem {
  id?: number;
  data?: string;
  geracaoInstaladores?: string;
  redutorMarca?: string;
  numeroSerie?: string;
  formaPagamento?: string;
  marcaCilindro?: string;
  numeroCilindro?: string;
  quilo?: number;
  litro?: number;
  anoFab?: number;
  
  anoReteste?: number;
  requalificadora?: string;
  numeroNFEquipamento?: string;
  numeroOrdemRequalificacao?: string;
  numeroLaudoMontagem?: string;
  marcaValvula?: string;
  numeroNFServicoMontagem?: string;
  numeroValvula?: string;
  selo?: string;
  pago?: boolean;
  
  instaladores?: string;
  valorTotal?: number;
  kitDaLoja?: boolean;
  veiculoId?: number;
  veiculo?: Veiculo;
  orcamentos?: Orcamento[];

    constructor(init?: Partial<Montagem>) {
      Object.assign(this, init);
    }
  }
  