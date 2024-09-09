import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Veiculo } from '../Models/VeiculoModel';
import { Observable } from 'rxjs';
import { Montagem } from '../Models/MontagemModel';


@Injectable({
  providedIn: 'root'
})
export class MontagemService {

  public url = 'http://localhost:5203/api/Montagem/montagem'
  public urlMont = 'http://localhost:5203/api/Montagem'

  constructor(public http : HttpClient) { }

  getMontagembydate(id: string): Observable<Montagem[]>{
    const urlID = `${this.url}/${id}`
    return this.http.get<Montagem[]>(urlID)
  }
  getAllMontagem(): Observable<Montagem[]>{
       return this.http.get<Montagem[]>(this.urlMont)
  }
}
