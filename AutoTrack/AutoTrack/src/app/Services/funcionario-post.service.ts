import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Funcionario } from '../Models/Funcionario';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FuncionarioPostService {

  url = 'http://localhost:5203/Funcionario/CadastroFuncionario'

  constructor(public http : HttpClient) { }

  PostFuncionario(funcionario : Funcionario):Observable<Funcionario>{
    return this.http.post<Funcionario>(this.url, funcionario);
    
  }
}