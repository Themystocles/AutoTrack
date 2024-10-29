import { Servico } from "./ServicoMode";

export interface OrcamentoFuncionarioDTO {
  nomeOrcamento: string;
  valorTotal: number;
  valorParcial: number;
  quantidade: number;
  dataOrc: string; // ou Date, dependendo de como você deseja manipular a data
  nomeServico?: string;        // Incluindo o nome do serviço
  especieVeiculo?: string;      // Incluindo a espécie do veículo
  placaVeiculo?: string;
}

export interface FuncionarioOrcamentosDTO {
  nomeFuncionario: string;
  cpfFuncionario: string;
  nomesOrcamentos: string[] | null; // Ajuste conforme necessário
  valoresTotais: number[] | null;   // Ajuste conforme necessário
  orcamentos: OrcamentoFuncionarioDTO[];
  nomeServico?: string;        // Incluindo o nome do serviço
  especieVeiculo?: string;      // Incluindo a espécie do veículo
  placaVeiculo?: string;
  servico?: Servico[];
}

export type FuncionarioOrcamentosResponse = FuncionarioOrcamentosDTO[];
