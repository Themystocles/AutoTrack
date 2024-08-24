import { Component, Input, EventEmitter, Output, OnInit } from '@angular/core';
import { Orcamento } from 'src/app/Models/OrcamentoModel';
import { OrcamentoPostService } from '../../../Services/CRUD - Cliente/orcamento-post.service';
import { FiltroEstoqueService } from 'src/app/Services/filtro-estoque.service';
import { Estoque } from 'src/app/Models/EstoqueModel';

@Component({
  selector: 'app-orcamento-post',
  templateUrl: './orcamento-post.component.html',
  styleUrls: ['./orcamento-post.component.scss']
})
export class OrcamentoPostComponent implements OnInit {
  @Input() servicoId: number | null = null;
  @Input() montagemId: number | null = null;
  @Output() orcamentosChange = new EventEmitter<Orcamento[]>();
  orcamentos: Orcamento[] = [];
  estoque: Estoque[] = [];

  constructor(
    private orcamentoPostService: OrcamentoPostService, 
    private estoqueService: FiltroEstoqueService
  ) {}

  ngOnInit() {
    if (this.servicoId !== null || this.montagemId !== null) {
      this.orcamentos.push(this.createEmptyOrcamento(this.servicoId, this.montagemId));
    }
    this.loadEstoque();
  }

  private loadEstoque() {
    this.estoqueService.getAllEstoque().subscribe(
      (data: Estoque[]) => {
        this.estoque = data;
      },
      error => {
        console.error('Erro ao carregar estoque:', error);
      }
    );
  }

  private createEmptyOrcamento(servicoId: number | null, montagemId: number | null): Orcamento {
    return {
      id: 0,
      quantidade: 0,
      nomeServico: '',
      produto: '',
      valorParcial: 0,
      valorTotal: 0,
      servicoId: servicoId || 0,
      estoqueId: 0,
      montagemId: montagemId || 0
    };
  }

  addOrcamento() {
    const servicoId = this.servicoId !== null ? this.servicoId : 0;
    const montagemId = this.montagemId !== null ? this.montagemId : 0;
    this.orcamentos.push(this.createEmptyOrcamento(servicoId, montagemId));
  }

  removeOrcamento(index: number) {
    this.orcamentos.splice(index, 1);
  }

  submitOrcamentos() {
    if (this.servicoId === null && this.montagemId === null) {
      console.error('Serviço ID e Montagem ID não estão definidos.');
      return;
    }

    this.orcamentos.forEach(orcamento => {
      orcamento.servicoId = this.servicoId || 0;
      orcamento.montagemId = this.montagemId || 0;
      this.orcamentoPostService.PostOrcamento(orcamento).subscribe(
        response => {
          console.log('Orçamento salvo com sucesso:', response);
        },
        error => {
          console.error('Erro ao salvar orçamento:', error);
        }
      );
    });

    this.orcamentosChange.emit(this.orcamentos);
  }

  getProdutoOptions() {
    return this.estoque.map(item => item.produto);
  }

  updateValorParcial(index: number) {
    const produtoSelecionado = this.orcamentos[index].nomeServico;
    const estoqueItem = this.estoque.find(item => item.produto === produtoSelecionado);

    if (estoqueItem) {
      this.orcamentos[index].valorParcial = estoqueItem.preco;
    } else {
      this.orcamentos[index].valorParcial = 0;
    }

    this.updateValorTotal(index); // Atualiza o valor total sempre que o valor parcial muda
  }

  updateValorTotal(index: number) {
    const orcamento = this.orcamentos[index];
    orcamento.valorTotal = orcamento.valorParcial * orcamento.quantidade;
  }

  updateQuantidade(index: number) {
    this.updateValorTotal(index); // Atualiza o valor total sempre que a quantidade muda
  }
}
