import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Veiculo } from 'src/app/Models/VeiculoModel';

@Injectable({
  providedIn: 'root'
})
export class VeiculoPutService {

 public url = 'http://localhost:5203/api/Veiculo/id'
  public urlPut = 'http://localhost:5203/api/Geral/veiculo'


  constructor(public http : HttpClient) { }

  GetVeiculoById(id: string): Observable<Veiculo>{
    const urlID = `${this.url}/${id}`
    return this.http.get<Veiculo>(urlID)
  }
  updateVeiculo(id : string, veiculo: Veiculo): Observable<Veiculo> {
   const url = `${this.urlPut}/${id}`;
   return this.http.put<Veiculo>(url, veiculo);
  }

}
