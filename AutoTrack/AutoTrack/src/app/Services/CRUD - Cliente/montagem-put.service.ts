import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Montagem } from 'src/app/Models/MontagemModel';

@Injectable({
  providedIn: 'root'
})
export class MontagemPutService {

  public url = 'http://localhost:5203/api/Montagem/idmontagem'
 public urlPut = 'http://localhost:5203/api/Geral/montagem'

 constructor(public http : HttpClient) { }

 GetMontagemById(id: string): Observable<Montagem>{
   const urlID = `${this.url}/${id}`
   return this.http.get<Montagem>(urlID)
 }
 UpdateMontagem(id : string, Montagem: Montagem): Observable<Montagem> {
  const url = `${this.urlPut}/${id}`;
  return this.http.put<Montagem>(url, Montagem);
 }
}
