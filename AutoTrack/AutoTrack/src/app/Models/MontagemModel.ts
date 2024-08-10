import { Veiculo } from "./VeiculoModel";

export class Montagem {
  id?: number;
  data?: string;
  geracaoInstaladores?: string;
  redutorValor?: number;
  numeroSerie?: string;
  formaPagamento?: string;
  marcaCilindro?: string;
  numeroCilindro?: number;
  quilo?: number;
  litro?: number;
  anoFab?: number;
  documentacaoAno?: number;
  anoReteste?: number;
  requalificadora?: string;
  numeroNFEquipamento?: string;
  numeroOrdemRequalificacao?: string;
  numeroLaudoMontagem?: string;
  marcaValvula?: string;
  numeroNFServicoMontagem?: string;
  numeroValvula?: string;
  selo?: string;
  orcamento?: number;
  quantPecaServico?: number;
  valorUnitario?: number;
  valorTotal?: number;
  kitDaLoja?: boolean;
  veiculo?: Veiculo;

    constructor(init?: Partial<Montagem>) {
      Object.assign(this, init);
    }
  }
  