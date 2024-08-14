import { Component } from '@angular/core';
import { MontagemPostService } from '../Services/CRUD - Cliente/montagem-post.service';
import { Veiculo } from '../Models/VeiculoModel';
import { Montagem } from '../Models/MontagemModel';

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
    // Verifique se todos os campos obrigatórios estão preenchidos
    if (!this.montagem.veiculoId) {
      alert('Por favor, preencha todos os campos obrigatórios.');
      return;
    }

    this.montagemservices.PostMontagem(this.montagem).subscribe(
      () => {
        this.showSuccessMessage = true;
        form.reset();
        this.veiculo = undefined; // Limpa o objeto veiculo após o envio
        this.montagem = new Montagem(); // Reseta o objeto montagem
      },
      error => {
        console.error('Erro ao enviar montagem:', error);
        alert('Erro ao cadastrar a montagem. Verifique os dados e tente novamente.');
      }
    );
  }
}
