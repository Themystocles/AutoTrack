import { Component } from '@angular/core';
import { Servico } from '../Models/ServicoMode';
import { ServicoPostService } from '../Services/CRUD - Cliente/servico-post.service';
import { Veiculo } from '../Models/VeiculoModel';

@Component({
  selector: 'app-servico-post',
  templateUrl: './servico-post.component.html',
  styleUrls: ['./servico-post.component.scss']
})
export class ServicoPostComponent {

  placaveiculo: string = ''; // Inicializa como uma string vazia
  veiculo: Veiculo | null = null;
  servico: Servico = new Servico();

  showSuccessMessage: boolean = false;

  constructor(public servicoServices: ServicoPostService) { }

  // Função para buscar veículo pelo número da placa
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


  // Função para enviar o serviço
  onSubmit(form: any) {
    // Verifique se todos os campos obrigatórios estão preenchidos
    if (this.servico.veiculoId === 0 || 
        !this.servico.descricao?.trim() || 
        !this.servico.peca_Servico?.trim() || 
        !this.servico.valorUni?.trim() || 
        !this.servico.valorTot?.trim() || 
        !this.servico.formaPag?.trim() || 
        !this.servico.mecanico?.trim() || 
        !this.servico.saida?.trim() || 
        !this.servico.dataServico?.trim()) {
      alert('Por favor, preencha todos os campos obrigatórios.');
      return;
    }

    console.log('Dados do serviço a serem enviados:', JSON.stringify(this.servico, null, 2));

    this.servicoServices.PostServico(this.servico).subscribe(
      () => {
        this.showSuccessMessage = true;
        form.reset();
        this.veiculo = null; // Limpa o objeto veiculo após o envio
        this.servico = new Servico(); // Reseta o objeto servico
      },
      error => {
        console.error('Erro ao enviar serviço:', error);
        alert('Erro ao cadastrar o serviço. Verifique os dados e tente novamente.');
      }
    );

  }


}
