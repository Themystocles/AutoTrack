import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Cliente } from 'src/app/Models/ClienteModel';
import { Veiculo } from 'src/app/Models/VeiculoModel';
import { VeiculoPostService } from 'src/app/Services/CRUD - Cliente/veiculo-post.service';

@Component({
  selector: 'app-veiculo-post',
  templateUrl: './veiculo-post.component.html',
  styleUrls: ['./veiculo-post.component.scss']
})
export class VeiculoPostComponent {

  erroMessage : string = '';

  clienteNome!: string;
  cliente: Cliente[] = [];
  veiculo: Veiculo = {
    id: 0,
    carro: '',
    placa: '',
    especie: '',
    combustivel: '',
    potencia: '',
    anoFab: '',
    capacidade: '',
    anoModelo: '',
    chassi: '',
    cor: '',
    observacao: '',
     
    renavam: '',
    clienteId: 0  // Este campo será atualizado com o ID do cliente selecionado
  };
  showSuccessMessage: boolean = false;

  constructor(public VeiculoPost: VeiculoPostService, private router: Router) {}

  GetClientesbynome() {
    this.VeiculoPost.getClientByNome(this.clienteNome).subscribe(res => {
        this.cliente = res;

        // Verifica se há apenas um cliente retornado
        if (this.cliente.length === 1) {
            this.selectCliente(this.cliente[0]); // Seleciona automaticamente o cliente
        }
        
    });
}

  selectCliente(cliente: Cliente) {
    this.veiculo.clienteId = cliente.id;
    this.cliente = [cliente]; // Exibe apenas o cliente selecionado
  }

  onSubmit(form: any) {
    if (this.veiculo.clienteId) {
      this.VeiculoPost.PostVeiculo(this.veiculo).subscribe(res => {
        this.showSuccessMessage = true;
        setTimeout(() => this.router.navigate(['/veiculo-list']), 2000); // Redireciona após 2 segundos
        form.reset();
      },error => {
        console.error('Erro ao cadastrar Veiculo', error);
        this.erroMessage = error.error; // Armazena a mensagem de erro
      });
    }
     else {
      alert('Por favor, selecione um cliente antes de cadastrar o veículo.');
    }
  }
}
