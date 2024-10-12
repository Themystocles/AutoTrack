import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ServicoPutService } from '../../../Services/CRUD - Cliente/servico-put.service';
import { OrcamentoPostService } from 'src/app/Services/CRUD - Cliente/orcamento-post.service';
import { Servico } from '../../../Models/ServicoMode';
import { Orcamento } from 'src/app/Models/OrcamentoModel';
import { Funcionario } from 'src/app/Models/Funcionario';
import { FuncionarioservicesService } from 'src/app/Services/CRUD - Cliente/funcionarioservices.service';
import { OrcamentodeleteService } from 'src/app/Services/CRUD - Cliente/orcamentodelete.service';
import { from } from 'rxjs';
import { ServicoDeleteService } from 'src/app/Services/CRUD - Cliente/servico-delete.service';
import { CrudEstoqueService } from 'src/app/Services/CRUD - Cliente/crud-estoque.service';
import { Estoque } from 'src/app/Models/EstoqueModel';

@Component({
  selector: 'app-servico-put',
  templateUrl: './servico-put.component.html',
  styleUrls: ['./servico-put.component.scss']
})
export class ServicoPutComponent implements OnInit, OnDestroy {
  servicoId!: string;
  servico: Servico = {} as Servico;
  showSuccessMessage = false;
  newOrcamento: Orcamento = {} as Orcamento;
  funcionario: Funcionario[] = [];
  servicoEstoque: Estoque[] = [];

  constructor(
    private route: ActivatedRoute,
    private servicoService: ServicoPutService,
    private orcamentoPostService: OrcamentoPostService,
    public funcionarioservices: FuncionarioservicesService,
    private router: Router,
    private orcamentodelete: OrcamentodeleteService,
    private servicodelete: ServicoDeleteService,
    private estoqueservices: CrudEstoqueService
  ) { }

  ngOnInit(): void {
    this.servicoId = this.route.snapshot.paramMap.get('id')!;
    this.loadServico();
    this.getfuncionarios();
    this.servicoestoque();
  }

  servicoestoque() {
    this.estoqueservices.getAllEstoque().subscribe(res => this.servicoEstoque = res)
  }

  ngOnDestroy(): void {
    // Chama o método onSubmit ao sair do componente
    const form = { valid: true }; // Simula um formulário válido
    this.onSubmit(form);
  }

  loadServico(): void {
    this.servicoService.GetServicoById(this.servicoId).subscribe(
      res => this.servico = res,
      error => console.error('Erro ao carregar o serviço:', error)
    );
  }

  getfuncionarios() {
    this.funcionarioservices.getfuncionarios().subscribe(
      res => this.funcionario = res,
      error => console.error('Erro ao carregar funcionários:', error)
    );
  }

  confirmDelete(id: number): void {
    const confirmed = confirm('Você realmente deseja deletar este orçamento?');

    if (confirmed) {
      this.deleteorc(id);
    }
  }

  deleteorc(id: number): void {
    this.orcamentodelete.DeleteOrcamento(id).subscribe({
      next: () => {
        alert('Orçamento deletado com sucesso!');
        this.updateOrcamentos();
      },
      error: (err) => {
        console.error('Erro ao deletar orçamento', err);
      }
    });
  }

  updateOrcamentos(): void {
    this.loadServico();
  }

  onSubmit(form: any): void {
    if (form.valid) {
      this.servicoService.UpdateServico(this.servicoId, this.servico).subscribe(
        () => {
          this.showSuccessMessage = true;
          setTimeout(() => this.router.navigate(['/servico-list']), 1000);
        },
        error => console.error('Erro ao atualizar serviço:', error)
      );
    }
  }

  addOrcamento(): void {
    if (this.newOrcamento.nomeServico && this.newOrcamento.quantidade) {
      this.newOrcamento.servicoId = Number(this.servicoId);
      this.servico.totalorcamento! += Number(this.newOrcamento.valorTotal);

      this.orcamentoPostService.PostOrcamento(this.newOrcamento).subscribe(
        (orcamento: Orcamento) => {
          if (!this.servico.orcamentos) {
            this.servico.orcamentos = [];
          }
          this.servico.orcamentos.push(orcamento);
          this.newOrcamento = {} as Orcamento;
        },
        error => console.error('Erro ao adicionar orçamento:', error)
      );
    } else {
      console.error('Preencha todos os campos do orçamento.');
    }


  }
  deleteServico() {
    // Exibe a mensagem de confirmação para o usuário
    const confirmacao = confirm('Ao deletar o serviço, você estará deletando todos os orçamentos atrelados. Deseja continuar?');

    // Verifica se o usuário confirmou a ação
    if (confirmacao) {
      this.servicodelete.deleteServico(this.servicoId).subscribe(res => {
        alert('Serviço deletado com sucesso');
        setTimeout(() => this.router.navigate(['/servico-list']), 2000);
      });
    } else {
      // Caso o usuário cancele, pode exibir uma mensagem ou não fazer nada
      alert('Ação cancelada');
    }
  }
}
