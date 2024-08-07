import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../Models/ClienteModel';
import { Veiculo } from '../Models/VeiculoModel';

@Injectable({
  providedIn: 'root'
})
export class FiltroServicesService {

  public url = 'http://localhost:5203/api/cliente'
  public urlTel = 'http://localhost:5203/api/cliente/telefone'
  public urlNome = 'http://localhost:5203/api/cliente/nome'
  public urlPlaca = 'http://localhost:5203/api/veiculo/veiculo'
 

  constructor(public http : HttpClient ) { }

  getClientByCpf(id: string): Observable<Cliente>{
    const urlID = `${this.url}/${id}`
    return this.http.get<Cliente>(urlID)
  }
  getClientByTelefone(id: string): Observable<Cliente>{
    const urlID = `${this.urlTel}/${id}`
    return this.http.get<Cliente>(urlID)
  }
  getClientByNome(id: string): Observable<Cliente>{
    const urlID = `${this.urlNome}/${id}`
    return this.http.get<Cliente>(urlID)
  }
  getVeiculoByplaca(id: string): Observable<Veiculo>{
    const urlID = `${this.urlPlaca}/${id}`
    return this.http.get<Veiculo>(urlID)
  }

}
