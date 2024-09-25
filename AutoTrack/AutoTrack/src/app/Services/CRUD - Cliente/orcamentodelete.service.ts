import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Orcamento } from '../../Models/OrcamentoModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrcamentodeleteService {

  public urlDel = 'http://localhost:5203/Orcamento'


  constructor(public http : HttpClient) { }

  DeleteOrcamento(id : number): Observable<Orcamento> {
    const url = `${this.urlDel}/${id}`;
    return this.http.delete<Orcamento>(url);
  }

}
