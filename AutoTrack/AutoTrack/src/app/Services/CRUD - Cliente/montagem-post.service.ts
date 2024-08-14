import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Montagem } from 'src/app/Models/MontagemModel';
import { Veiculo } from 'src/app/Models/VeiculoModel';

@Injectable({
  providedIn: 'root'
})
export class MontagemPostService {
  public urlPlaca = 'http://localhost:5203/api/Veiculo/veiculo'
  public url = 'http://localhost:5203/api/Geral/montagem'
  constructor(public http : HttpClient) { }

  GetveiculoByPlaca(placa : string):Observable<Veiculo>{
    const urlID = `${this.urlPlaca}/${placa}`;
    return this.http.get<Veiculo>(urlID)
  }
  PostMontagem(Montagem : Montagem):Observable<Montagem>{
    return this.http.post<Montagem>(this.url, Montagem)
  }


}
