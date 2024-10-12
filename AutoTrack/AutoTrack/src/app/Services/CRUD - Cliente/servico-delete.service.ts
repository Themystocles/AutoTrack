import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Servico } from 'src/app/Models/ServicoMode';

@Injectable({
  providedIn: 'root'
})
export class ServicoDeleteService {

  public url = 'http://localhost:5203/api/Servico'

  constructor(public http: HttpClient) { }

  deleteServico(id: string): Observable<Servico> {
    const urlId = `${this.url}/${id}`;
    return this.http.delete<Servico>(urlId);
  }
}
