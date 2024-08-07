import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Veiculo } from '../Models/VeiculoModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FiltroVeiculoService {

  public urlPlaca = 'http://localhost:5203/api/veiculo/veiculo'
  public urlChassi = 'http://localhost:5203/api/veiculo/chassi'


  constructor(public http : HttpClient  ) { }

  getVeiculoByPlaca(id: string): Observable<Veiculo>{
    const urlID = `${this.urlPlaca}/${id}`
    return this.http.get<Veiculo>(urlID)
  }
  getVeiculoBychassi(id: string): Observable<Veiculo>{
    const urlID = `${this.urlChassi}/${id}`
    return this.http.get<Veiculo>(urlID)
  }
}
