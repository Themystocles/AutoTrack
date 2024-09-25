import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MontagemPutService } from 'src/app/Services/CRUD - Cliente/montagem-put.service';
import { OrcamentoPostService } from 'src/app/Services/CRUD - Cliente/orcamento-post.service';
import { Montagem } from 'src/app/Models/MontagemModel';
import { Orcamento } from 'src/app/Models/OrcamentoModel';
import { Funcionario } from 'src/app/Models/Funcionario';
import { FuncionarioservicesService } from 'src/app/Services/CRUD - Cliente/funcionarioservices.service';
import { OrcamentodeleteService } from 'src/app/Services/CRUD - Cliente/orcamentodelete.service';

@Component({
  selector: 'app-montagem-put',
  templateUrl: './montagem-put.component.html',
  styleUrls: ['./montagem-put.component.scss']
})
export class MontagemPutComponent implements OnInit, OnDestroy {
  MontagemId!: string;
  Montagem: Montagem = {} as Montagem;
  showSuccessMessage = false;
  newOrcamento: Orcamento = {} as Orcamento; // Para adicionar um novo orçamento
  funcionario: Funcionario[] = [];

  constructor(
    private route: ActivatedRoute,
    private MontagemServices: MontagemPutService,
    private orcamentoPostService: OrcamentoPostService,
    public funcionarioservices: FuncionarioservicesService,
    private router: Router,
    private orcamentodelete : OrcamentodeleteService
  ) {}

  ngOnInit(): void {
    this.MontagemId = this.route.snapshot.paramMap.get('id')!;
    this.loadMontagem();
    this.getfuncionarios();
    console.log(this.funcionario);
    console.log(this.newOrcamento);
  }
  ngOnDestroy(): void {
    // Chama o método onSubmit ao sair do componente
    const form = { valid: true }; // Simula um formulário válido
    this.onSubmit(form);
  }

  loadMontagem(): void {
    this.MontagemServices.GetMontagemById(this.MontagemId).subscribe(
      res => this.Montagem = res,
      error => console.error('Erro ao carregar a montagem:', error)
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
        // Sucesso no delete, atualize a página ou redirecione para outra rota
        alert('Orçamento deletado com sucesso!');
       
        location.reload(); // Recarrega a página atual
     
      },
      error: (err) => {
        console.error('Erro ao deletar orçamento', err);
      }
    });
  }
  onSubmit(form: any): void {
    console.log(this.Montagem);
    if (form.valid) {
      this.MontagemServices.UpdateMontagem(this.MontagemId, this.Montagem).subscribe(
        () => {
          this.showSuccessMessage = true;
          setTimeout(() => this.router.navigate(['/montagem-list']), 1000);
        },
        error => console.error('Erro ao atualizar montagem:', error)
      );
    }
  }

  addOrcamento(): void {
    if (this.newOrcamento.nomeServico && this.newOrcamento.quantidade) {
      this.newOrcamento.montagemId = Number(this.MontagemId);
      this.Montagem.valorTotal! += Number(this.newOrcamento.valorTotal)
      this.orcamentoPostService.PostOrcamento(this.newOrcamento).subscribe(
        (orcamento: Orcamento) => {
          if (!this.Montagem.orcamentos) {
            this.Montagem.orcamentos = [];
          }
          this.Montagem.orcamentos.push(orcamento);
          this.newOrcamento = {} as Orcamento;
        },
        error => console.error('Erro ao adicionar orçamento:', error)
      );
    } else {
      console.error('Preencha todos os campos do orçamento.');
    }
  }
}
