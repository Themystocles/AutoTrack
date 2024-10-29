import { Funcionario } from "./Funcionario";
import { Servico } from "./ServicoMode";
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
  servico?: Servico[];
  orcamentoFuncionarios?: OrcamentoFuncionario[];


}
