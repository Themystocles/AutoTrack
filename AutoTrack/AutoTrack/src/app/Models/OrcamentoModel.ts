export interface Orcamento {
    id?: number;
    quantidade: number;
    nomeServico: string;
    produto?: string;
    valorParcial: number;
    valorTotal: number;
    kmAtual?: string;
    servicoId: number;
    estoqueId: number;
    montagemId: number;

  }
  