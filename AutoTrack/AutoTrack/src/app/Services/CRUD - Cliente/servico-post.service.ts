import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Servico } from 'src/app/Models/ServicoMode';
import { Veiculo } from 'src/app/Models/VeiculoModel';

@Injectable({
  providedIn: 'root'
})
export class ServicoPostService {

  public urlPlaca = 'http://localhost:5203/api/Veiculo/veiculo'
  public url = 'http://localhost:5203/api/Geral/servicos'

  constructor(public http : HttpClient) { }

  GetVeiculobyPlaca(placa : string):Observable<Veiculo>{
    const urlID = `${this.urlPlaca}/${placa}`;
    return this.http.get<Veiculo>(urlID)
  }
 PostServico(Servico : Servico):Observable<Servico>{
  return this.http.post<Servico>(this.url, Servico );
 }
  
  
}
