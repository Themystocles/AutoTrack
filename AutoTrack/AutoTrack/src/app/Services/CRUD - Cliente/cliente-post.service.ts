import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from 'src/app/Models/ClienteModel';

@Injectable({
  providedIn: 'root'
})
export class ClientePostService {

  public url = 'http://localhost:5203/api/Cliente'

  constructor(public http : HttpClient) { }

  PostCliente(Cliente : Cliente):Observable<Cliente>{
    return this.http.post<Cliente>(this.url, Cliente);
    
  }
}
