import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Estoque } from 'src/app/Models/EstoqueModel';

@Injectable({
  providedIn: 'root'
})
export class CrudEstoqueService {
  urlGet='http://localhost:5203/api/Estoque/Estoque'
  urlGetById ='http://localhost:5203/api/Estoque/Estoque'
  urlPost = 'http://localhost:5203/api/Estoque/CadastrarItem'
  urlPut = 'http://localhost:5203/api/Estoque'
  urldelete ='http://localhost:5203/api/Estoque/RemoverEstoque'


  constructor(public http : HttpClient ) { }

  getAllEstoque(): Observable<Estoque[]>{
    return this.http.get<Estoque[]>(this.urlGet)
  }

  getEstoquebyId(id: string):Observable<Estoque>{
    const GetId = `${this.urlGetById}/${id}`;
    return this.http.get<Estoque>(GetId)

  }
    
  postEstoque(estoque : Estoque): Observable<Estoque>{
    return this.http.post<Estoque>(this.urlPost, estoque);

  }

  putEstoque(id : string, estoque : Estoque): Observable<Estoque>{
    const consturlPut = `${this.urlPut}/EditarItem/${id}`;
   return this.http.put<Estoque>(consturlPut, estoque);
  } 
  deleteEstoque(id: string): Observable<Estoque>{
    const consturlDelete = `${this.urldelete}/${id}`;
    return this.http.delete<Estoque>(consturlDelete)
  }
}
