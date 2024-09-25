import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Orcamento } from 'src/app/Models/OrcamentoModel';

@Injectable({
  providedIn: 'root'
})
export class OrcamentoPostService {
  public url = 'http://localhost:5203/Orcamento/Orcamento';
  

  constructor(public http: HttpClient) { }

  PostOrcamento(orcamento: Orcamento): Observable<Orcamento> {
    return this.http.post<Orcamento>(this.url, orcamento);
  }
}
