import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Servico } from 'src/app/Models/ServicoMode';

@Injectable({
  providedIn: 'root'
})
export class ServicoPutService {

   public url = 'http://localhost:5203/api/Servico/idServico'
  public urlPut = 'http://localhost:5203/api/Servico/servico'

  constructor(public http : HttpClient) { }

  GetServicoById(id: string): Observable<Servico>{
    const urlID = `${this.url}/${id}`
    return this.http.get<Servico>(urlID)
  }
  UpdateServico(id : string, servico: Servico): Observable<Servico> {
   const url = `${this.urlPut}/${id}`;
   return this.http.put<Servico>(url, servico);
  }
}
