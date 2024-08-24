import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Cliente } from 'src/app/Models/ClienteModel';
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

  showSuccessMessage: boolean = false;

  constructor(private Clientepost: ClientePostService) { }

  onSubmit(form: NgForm) {
    this.Clientepost.PostCliente(this.Cliente).subscribe(
      res => {
        console.log('Cliente cadastrado com sucesso', res);
        this.showSuccessMessage = true;

        // Limpar o formulário
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
          cep: '',
          uf: '',
          veiculos: []
        };
        form.resetForm();
      },
      error => {
        console.error('Erro ao cadastrar cliente', error);
      }
    );
  }
}
