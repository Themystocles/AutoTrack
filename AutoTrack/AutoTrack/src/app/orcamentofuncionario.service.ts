import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Funcionario } from './Models/Funcionario';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrcamentofuncionarioService {

  

  constructor(public http : HttpClient) { }

  getFuncionariosPorOrcamento(orcamentoId: number): Observable<Funcionario[]> {
    return this.http.get<Funcionario[]>(`http://localhost:5203/Orcamento/orcamentos/${orcamentoId}/funcionarios`);
  }
}
