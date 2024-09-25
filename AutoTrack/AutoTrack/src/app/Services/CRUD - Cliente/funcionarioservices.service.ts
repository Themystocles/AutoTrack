import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Funcionario } from 'src/app/Models/Funcionario';

@Injectable({
  providedIn: 'root'
})
export class FuncionarioservicesService {
  url = 'http://localhost:5203/Funcionario/Funcionario'

  

  constructor(public http: HttpClient) { }

getfuncionarios():Observable<Funcionario[]>{
  return this.http.get<Funcionario[]>(this.url)
}
getfuncionariosbyId(id: string):Observable<Funcionario>{
  const urlId = `${this.url}/${id}`;
  return this.http.get<Funcionario>(urlId)
}


}
