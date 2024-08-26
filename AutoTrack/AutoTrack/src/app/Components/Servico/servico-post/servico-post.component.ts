import { Component, ViewChild } from '@angular/core';
import { Servico } from '../../../Models/ServicoMode';
import { ServicoPostService } from '../../../Services/CRUD - Cliente/servico-post.service';
import { Veiculo } from '../../../Models/VeiculoModel';
import { OrcamentoPostComponent } from '../../Orcamento/orcamento-post/orcamento-post.component';
import { Orcamento } from '../../../Models/OrcamentoModel'; // Adicione o modelo Orcamento se não estiver importado

@Component({
  selector: 'app-servico-post',
  templateUrl: './servico-post.component.html',
  styleUrls: ['./servico-post.component.scss']
})
export class ServicoPostComponent {
  placaveiculo: string = '';
  veiculo: Veiculo | null = null;
  servico: Servico = new Servico();
  showSuccessMessage: boolean = false;
  orcamentos: Orcamento[] = []; 

  @ViewChild(OrcamentoPostComponent) orcamentoComponent?: OrcamentoPostComponent;

  constructor(public servicoServices: ServicoPostService) { }

  GetVeiculoByPlaca() {
    if (!this.placaveiculo.trim()) {
      alert('Placa não pode ser vazia.');
      return;
    }

    this.servicoServices.GetVeiculobyPlaca(this.placaveiculo).subscribe(
      res => {
        this.veiculo = res;
        if (this.veiculo) {
          this.servico.veiculoId = this.veiculo.id;
        }
      },
      error => {
        console.error('Erro ao buscar veículo:', error);
        alert('Não foi possível encontrar o veículo com a placa fornecida.');
      }
    );
  }

  onSubmit(form: any) {
    if (this.servico.veiculoId === 0 || 
        !this.servico.descricao?.trim() || 
        
        !this.servico.formaPag?.trim() || 
        !this.servico.mecanico?.trim() || 
        !this.servico.observacao?.trim() ) {
      alert('Por favor, preencha todos os campos obrigatórios.');
      return;
    }

    this.servicoServices.PostServico(this.servico).subscribe(
      (savedServico) => {
        if (this.orcamentoComponent) {
          const servicoId: number | null = savedServico.id ?? null;
          if (servicoId !== null) {
            this.orcamentoComponent.servicoId = servicoId;
            this.orcamentoComponent.submitOrcamentos(); // Envia os orçamentos associados
          }
        }
        this.showSuccessMessage = true;
        form.reset();
        this.veiculo = null;
        this.servico = new Servico();
        this.orcamentos = []; // Limpa a lista de orçamentos
      },
      error => {
        console.error('Erro ao enviar serviço:', error);
        alert('Erro ao cadastrar o serviço. Verifique os dados e tente novamente.');
      }
    );
  }

  receiveOrcamentos(orcamentos: Orcamento[]) {
    this.orcamentos = orcamentos;
  }
}
