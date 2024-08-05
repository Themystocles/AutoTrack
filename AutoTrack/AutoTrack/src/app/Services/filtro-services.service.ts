import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../Models/ClienteModel';

@Injectable({
  providedIn: 'root'
})
export class FiltroServicesService {

  public url = 'http://localhost:5203/api/cliente'

  constructor(public http : HttpClient ) { }

  getClientByCpf(id: string): Observable<Cliente>{
    const urlID = `${this.url}/${id}`
    return this.http.get<Cliente>(urlID)
  }
}
