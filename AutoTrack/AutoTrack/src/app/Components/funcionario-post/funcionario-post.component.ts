import { Component } from '@angular/core';
import { Funcionario } from 'src/app/Models/Funcionario';
import { FuncionarioPostService } from 'src/app/Services/funcionario-post.service';

@Component({
  selector: 'app-funcionario-post',
  templateUrl: './funcionario-post.component.html',
  styleUrls: ['./funcionario-post.component.scss']
})
export class FuncionarioPostComponent {

  novoFuncionario : Funcionario = {
    id: 0,
    nome: '',
    cpf: '',
    dataAdmissao: null,
    dataDemissao: null,
    situacao: '',
    dataFerias: null,
    funcao: '',
    dataNascimento: null,
    celular1: '',
    celular2: '',
    rua: '',
    cep: '',
    cidade: '',
    bairro: '',
    foto: null  
  };
  mensagemSucesso: string = '';


  constructor(public funcionariopost: FuncionarioPostService) {
    
    
  }

  postfuncionario(){
    this.funcionariopost.PostFuncionario(this.novoFuncionario).subscribe()
    this.mensagemSucesso = 'Funcionário Salvo com sucesso!';
  setTimeout(() => {
    this.mensagemSucesso = '';
  }, 3000);
  }

}
