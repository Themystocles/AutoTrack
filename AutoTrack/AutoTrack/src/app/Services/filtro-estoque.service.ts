import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Estoque } from '../Models/EstoqueModel';

@Injectable({
  providedIn: 'root'
})
export class FiltroEstoqueService {

 url='http://localhost:5203/api/Estoque/Estoque'

  constructor(public http : HttpClient) { }

  getAllEstoque(): Observable<Estoque[]>{
    return this.http.get<Estoque[]>(this.url)
  }





}