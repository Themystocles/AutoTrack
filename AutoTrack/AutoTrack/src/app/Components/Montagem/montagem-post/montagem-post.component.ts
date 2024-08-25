import { Component, ViewChild } from '@angular/core';
import { MontagemPostService } from '../../../Services/CRUD - Cliente/montagem-post.service';
import { Veiculo } from '../../../Models/VeiculoModel';
import { Montagem } from '../../../Models/MontagemModel';
import { OrcamentoPostComponent } from '../../Orcamento/orcamento-post/orcamento-post.component';
import { Orcamento } from '../../../Models/OrcamentoModel'; // Adicione o modelo Orcamento se não estiver importado

@Component({
  selector: 'app-montagem-post',
  templateUrl: './montagem-post.component.html',
  styleUrls: ['./montagem-post.component.scss']
})
export class MontagemPostComponent {
  placaveiculo: string = '';
  veiculo?: Veiculo;
  montagem: Montagem = new Montagem();
  showSuccessMessage: boolean = false;
  orcamentos: Orcamento[] = []; 

  @ViewChild(OrcamentoPostComponent) orcamentoComponent?: OrcamentoPostComponent;

  constructor(public montagemservices: MontagemPostService) {}

  GetVeiculoByPlaca() {
    if (!this.placaveiculo.trim()) {
      alert('Placa não pode ser vazia.');
      return;
    }

    this.montagemservices.GetveiculoByPlaca(this.placaveiculo).subscribe(
      res => {
        this.veiculo = res;
        if (this.veiculo) {
          this.montagem.veiculoId = this.veiculo.id;
        }
      },
      error => {
        console.error('Erro ao buscar veículo:', error);
        alert('Não foi possível encontrar o veículo com a placa fornecida.');
      }
    );
  }

  onSubmit(form: any) {
    if (!this.montagem.veiculoId || !this.montagem.formaPagamento?.trim() ) {
      alert('Por favor, preencha todos os campos obrigatórios.');
      return;
    }

    this.montagemservices.PostMontagem(this.montagem).subscribe(
      (savedMontagem) => {
        if (this.orcamentoComponent) {
          const montagemId: number | null = savedMontagem.id ?? null;
          if (montagemId !== null) {
            this.orcamentoComponent.montagemId = montagemId;
            this.orcamentoComponent.submitOrcamentos(); // Envia os orçamentos associados
          }
        }
        this.showSuccessMessage = true;
        form.reset();
        this.veiculo = undefined; // Limpa o objeto veiculo após o envio
        this.montagem = new Montagem(); // Reseta o objeto montagem
        this.orcamentos = []; // Limpa a lista de orçamentos
      },
      error => {
        console.error('Erro ao enviar montagem:', error);
        alert('Erro ao cadastrar a montagem. Verifique os dados e tente novamente.');
      }
    );
  }

  receiveOrcamentos(orcamentos: Orcamento[]) {
    this.orcamentos = orcamentos;
  }
}
