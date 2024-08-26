import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cep } from '../Models/Cep';

@Injectable({
  providedIn: 'root'
})
export class CepService {

  private apiUrl = 'https://viacep.com.br/ws';

  constructor(private http: HttpClient) { }

  getEnderecoPorCep(cep: string): Observable<Cep> {
    const url = `${this.apiUrl}/${cep}/json`;
    return this.http.get<Cep>(url);
  }
}