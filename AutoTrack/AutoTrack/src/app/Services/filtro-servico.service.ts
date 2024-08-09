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

  constructor(public http : HttpClient) { }

  getservicobydate(id: string): Observable<Servico[]>{
    const urlID = `${this.url}/${id}`
    return this.http.get<Servico[]>(urlID)
  }
}
