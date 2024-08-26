import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Cep } from 'src/app/Models/Cep';
import { Cliente } from 'src/app/Models/ClienteModel';
import { CepService } from 'src/app/Services/cep.service';
import { ClientePostService } from 'src/app/Services/CRUD - Cliente/cliente-post.service';

@Component({
  selector: 'app-cliente-post',
  templateUrl: './cliente-post.component.html',
  styleUrls: ['./cliente-post.component.scss']
})
export class ClientePostComponent {
  Cliente: Cliente = {
    id: 0,
    nome: '',
    cpf: '',
    insEstadual: '',
    insMunicipal: '',
    telefone: '',
    insTelefone2: '',
    endereco: '',
    bairro: '',
    cidade: '',
    cep: '',
    uf: '',
    veiculos: []
  };
  cep: string = '';
  endereco?: Cep;

  showSuccessMessage: boolean = false;

  constructor(private clientePostService: ClientePostService, public cepService: CepService) { }

  PesquisaPorCep() {
    this.cepService.getEnderecoPorCep(this.cep).subscribe(res => {
      this.endereco = res;
      
      if (this.endereco) {
        this.Cliente.endereco = this.endereco.logradouro || '';
        this.Cliente.bairro = this.endereco.bairro || '';
        this.Cliente.cidade = this.endereco.localidade || '';
        this.Cliente.uf = this.endereco.uf || '';
        this.Cliente.cep = this.endereco.cep || '';
      }
    });
  }

  onSubmit(form: NgForm) {
    this.clientePostService.PostCliente(this.Cliente).subscribe(
      res => {
        console.log('Cliente cadastrado com sucesso', res);
        this.showSuccessMessage = true;

        // Não limpar o campo CEP
        this.Cliente = {
          id: 0,
          nome: '',
          cpf: '',
          insEstadual: '',
          insMunicipal: '',
          telefone: '',
          insTelefone2: '',
          endereco: '',
          bairro: '',
          cidade: '',
          cep: this.Cliente.cep,  // Manter o CEP existente
          uf: '',
          veiculos: []
        };
        form.resetForm();
        // Manter o valor do campo de CEP no formulário
        this.Cliente.cep = this.cep;
      },
      error => {
        console.error('Erro ao cadastrar cliente', error);
      }
    );
  }
}
