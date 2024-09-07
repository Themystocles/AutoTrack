import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Veiculo } from '../Models/VeiculoModel';
import { Observable } from 'rxjs';
import { Servico } from '../Models/ServicoMode';
import { valtot } from '../Models/ValTot';


@Injectable({
  providedIn: 'root'
})
export class ServicoService {

  public url = 'http://localhost:5203/api/Servico/servico'
  public urlallServ = 'http://localhost:5203/api/Geral/servicos'
  public urlValTot = 'http://localhost:5203/api/Servico/com-valores-totais'
  public urlalert ='http://localhost:5203/api/Servico/alertservico'

  constructor(public http : HttpClient) { }

  getservicobydate(id: string): Observable<Servico[]>{
    const urlID = `${this.url}/${id}`
    return this.http.get<Servico[]>(urlID)
  }
  getservicobydateAlert(id: string): Observable<Servico[]>{
    const urlIDAlert = `${this.urlalert}/${id}`
    return this.http.get<Servico[]>(urlIDAlert)
  }
  getallServicos(): Observable<Servico[]>{
   return this.http.get<Servico[]>(this.urlallServ)
  }
  getValTot():Observable<valtot[]>{
    return this.http.get<valtot[]>(this.url)
  }
}
