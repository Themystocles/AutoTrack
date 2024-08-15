import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from 'src/app/Models/ClienteModel';

@Injectable({
  providedIn: 'root'
})
export class ClientePutService {

  public url = 'http://localhost:5203/api/Cliente/id'
  public urlPut = 'http://localhost:5203/api/Geral/cliente'


  constructor(public http : HttpClient) { }
  
  getClientById(id: string): Observable<Cliente>{
    const urlID = `${this.url}/${id}`
    return this.http.get<Cliente>(urlID)
  }
  updateClient(id : string, cliente: Cliente): Observable<Cliente> {
    const url = `${this.urlPut}/${id}`;
    return this.http.put<Cliente>(url, cliente);
  }


}
