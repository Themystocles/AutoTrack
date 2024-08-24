import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MontagemPutService } from 'src/app/Services/CRUD - Cliente/montagem-put.service';
import { OrcamentoPostService } from 'src/app/Services/CRUD - Cliente/orcamento-post.service';
import { Montagem } from 'src/app/Models/MontagemModel';
import { Orcamento } from 'src/app/Models/OrcamentoModel';

@Component({
  selector: 'app-montagem-put',
  templateUrl: './montagem-put.component.html',
  styleUrls: ['./montagem-put.component.scss']
})
export class MontagemPutComponent implements OnInit {
  MontagemId!: string;
  Montagem: Montagem = {} as Montagem;
  showSuccessMessage = false;
  newOrcamento: Orcamento = {} as Orcamento; // Para adicionar um novo orçamento

  constructor(
    private route: ActivatedRoute,
    private MontagemServices: MontagemPutService,
    private orcamentoPostService: OrcamentoPostService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.MontagemId = this.route.snapshot.paramMap.get('id')!;
    this.loadMontagem();
  }

  loadMontagem(): void {
    this.MontagemServices.GetMontagemById(this.MontagemId).subscribe(
      res => this.Montagem = res,
      error => console.error('Erro ao carregar a montagem:', error)
    );
  }

  onSubmit(form: any): void {
    if (form.valid) {
      this.MontagemServices.UpdateMontagem(this.MontagemId, this.Montagem).subscribe(
        () => {
          this.showSuccessMessage = true;
          setTimeout(() => this.router.navigate(['/montagem-list']), 2000);
        },
        error => console.error('Erro ao atualizar montagem:', error)
      );
    }
  }

  addOrcamento(): void {
    if (this.newOrcamento.nomeServico && this.newOrcamento.quantidade) {
      this.newOrcamento.montagemId = Number(this.MontagemId);
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
