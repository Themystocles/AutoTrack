import { Component } from '@angular/core';
import { VeiculoPostService } from '../Services/CRUD - Cliente/veiculo-post.service';
import { Veiculo } from '../Models/VeiculoModel';
import { Cliente } from '../Models/ClienteModel';

@Component({
  selector: 'app-veiculo-post',
  templateUrl: './veiculo-post.component.html',
  styleUrls: ['./veiculo-post.component.scss']
})
export class VeiculoPostComponent {

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
    kmAtual: '',
    proxManutencao: '',
    proxTrocaFiltro: '',
    garantia: '',
    renavam: '',
    clienteId: 0  // Este campo será atualizado com o ID do cliente selecionado
  };
  showSuccessMessage: boolean = false;

  constructor(public VeiculoPost: VeiculoPostService) {}

  GetClientesbynome() {
    this.VeiculoPost.getClientByNome(this.clienteNome).subscribe(res => this.cliente = res);
  }

  selectCliente(cliente: Cliente) {
    this.veiculo.clienteId = cliente.id;
    this.cliente = [cliente]; // Exibe apenas o cliente selecionado
  }

  onSubmit(form: any) {
    if (this.veiculo.clienteId) {
      this.VeiculoPost.PostVeiculo(this.veiculo).subscribe(res => {
        this.showSuccessMessage = true;
        form.reset();
      });
    } else {
      alert('Por favor, selecione um cliente antes de cadastrar o veículo.');
    }
  }
}
