import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Montagem } from 'src/app/Models/MontagemModel';
import { Orcamento } from 'src/app/Models/OrcamentoModel';
import { Veiculo } from 'src/app/Models/VeiculoModel';

@Injectable({
  providedIn: 'root'
})
export class MontagemPostService {
  public urlPlaca = 'http://localhost:5203/api/Veiculo/veiculo'
  public url = 'http://localhost:5203/api/Geral/montagem'
   public baseUrl = 'http://localhost:5203/api/Geral/Orcamento'
  constructor(public http : HttpClient) { }

  GetveiculoByPlaca(placa : string):Observable<Veiculo>{
    const urlID = `${this.urlPlaca}/${placa}`;
    return this.http.get<Veiculo>(urlID)
  }
  PostMontagem(Montagem : Montagem):Observable<Montagem>{
    return this.http.post<Montagem>(this.url, Montagem)
  }

  PostOrcamento(orcamento: Orcamento): Observable<any> {
    return this.http.post(`${this.baseUrl}/orcamentos`, orcamento);
  }


}
