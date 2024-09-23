import { Funcionario } from "./Funcionario";
export interface OrcamentoFuncionario {
  orcamentoId: number; 
  funcionarioId: number;
  funcionario?: Funcionario;
}

export interface Orcamento {
    id?: number;
    quantidade: number;
    nomeServico: string;
    produto?: string;
    valorParcial: number;
    valorTotal: number;
    garantia?: string;
    kmAtual?: string;
    servicoId: number;
    estoqueId: number;
    montagemId: number;
    funcionariosIds?: number[];
    funcionarios?: Funcionario[];
    orcamentoFuncionarios?: OrcamentoFuncionario[];
    

  }
  