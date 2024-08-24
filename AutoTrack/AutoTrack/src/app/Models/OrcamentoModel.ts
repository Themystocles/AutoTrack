export interface Orcamento {
    id?: number;
    quantidade: number;
    nomeServico: string;
    produto?: string;
    valorParcial: number;
    valorTotal: number;
    servicoId: number;
    estoqueId: number;
    montagemId: number;
  }
  