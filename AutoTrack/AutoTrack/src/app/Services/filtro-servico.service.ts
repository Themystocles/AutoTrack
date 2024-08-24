import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Veiculo } from '../Models/VeiculoModel';
import { Observable } from 'rxjs';
import { Servico } from '../Models/ServicoMode';


@Injectable({
  providedIn: 'root'
})
export class ServicoService {

  public url = 'http://localhost:5203/api/Servico/servico'
  public urlallServ = 'http://localhost:5203/api/Geral/servicos'
  

  constructor(public http : HttpClient) { }

  getservicobydate(id: string): Observable<Servico[]>{
    const urlID = `${this.url}/${id}`
    return this.http.get<Servico[]>(urlID)
  }
  getallServicos(): Observable<Servico[]>{
   return this.http.get<Servico[]>(this.urlallServ)
  }
}
