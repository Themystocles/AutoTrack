export interface OrcamentoFuncionarioDTO {
    nomeOrcamento: string;
    valorTotal: number;
    valorParcial: number;
    quantidade: number;
    dataOrc: string; // ou Date, dependendo de como você deseja manipular a data
  }
  
  export interface FuncionarioOrcamentosDTO {
    nomeFuncionario: string;
    cpfFuncionario: string;
    nomesOrcamentos: string[] | null; // Ajuste conforme necessário
    valoresTotais: number[] | null;   // Ajuste conforme necessário
    orcamentos: OrcamentoFuncionarioDTO[];
  }
  
  export type FuncionarioOrcamentosResponse = FuncionarioOrcamentosDTO[];
  