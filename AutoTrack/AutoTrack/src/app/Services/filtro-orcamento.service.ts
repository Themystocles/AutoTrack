import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Orcamento } from '../Models/OrcamentoModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FiltroOrcamentoService {

  url='http://localhost:5203/api/Geral/orcamentos'

  constructor(public http : HttpClient) { }

  getAllEstoque(): Observable<Orcamento[]>{
    return this.http.get<Orcamento[]>(this.url)
  }
}
