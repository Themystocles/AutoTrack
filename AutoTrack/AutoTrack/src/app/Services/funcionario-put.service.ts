import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Funcionario } from '../Models/Funcionario';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FuncionarioPutService {

  urlPut ='http://localhost:5203/Funcionario/FuncionarioPut'
  urlget = 'http://localhost:5203/Funcionario/Funcionario'

  constructor(public http : HttpClient) { }

  getfuncionariosbyId(id: string):Observable<Funcionario>{
    const urlId = `${this.urlget}/${id}`;
    return this.http.get<Funcionario>(urlId)
  }

  updateFuncionario(id : number, funcionario: Funcionario): Observable<Funcionario> {
    const url = `${this.urlPut}/${id}`;
    return this.http.put<Funcionario>(url, funcionario);
  }
}
