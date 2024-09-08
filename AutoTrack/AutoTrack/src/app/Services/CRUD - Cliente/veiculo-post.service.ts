import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from 'src/app/Models/ClienteModel';
import { Veiculo } from 'src/app/Models/VeiculoModel';


@Injectable({
  providedIn: 'root'
})
export class VeiculoPostService {

  public urlNome = 'http://localhost:5203/api/cliente/nome'
  public url = 'http://localhost:5203/api/Veiculo/veiculos'

  constructor(public http : HttpClient) { }

  getClientByNome(nome: string): Observable<Cliente[]> {
    const urlID = `${this.urlNome}/${nome}`;
    return this.http.get<Cliente[]>(urlID);
  }
  PostVeiculo(Veiculo : Veiculo):Observable<Veiculo>{
    return this.http.post<Veiculo>(this.url, Veiculo);
    
  }
}
