import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Servico } from '../Models/ServicoMode';
import { Observable } from 'rxjs';
import { Montagem } from '../Models/MontagemModel';

@Injectable({
  providedIn: 'root'
})
export class NotificacaoService {

  private UrlCount = 'http://localhost:5203/api/Servico/servicos/nao-pagos';
  private UrlList = 'http://localhost:5203/api/Servico/listServicos/nao-pagos';
  private UrlCountMont = 'http://localhost:5203/api/Montagem/montagem/nao-pagos';
  private UrlListMont = 'http://localhost:5203/api/Montagem/listMontagens/nao-pagos';
  private UrlPendentes = 'http://localhost:5203/api/Servico/servicos/Em%20Andamento'
  private UrlPendentesMont = 'http://localhost:5203/api/Montagem/Montagem/mont/Em%20andamento'


  constructor(private http: HttpClient) { }

  getQtdNaoPago(): Observable<number> {
    return this.http.get<number>(this.UrlCount);
  }

  getListNaoPagos(): Observable<Servico[]> {
    return this.http.get<Servico[]>(this.UrlList)
  }

  getQtdMontNaoPago(): Observable<number> {
    return this.http.get<number>(this.UrlCountMont);
  }
  getListMontNaoPagos(): Observable<Montagem[]> {
    return this.http.get<Montagem[]>(this.UrlListMont)
  }
  getLisServicosNFinalizados(): Observable<Servico[]> {
    return this.http.get<Servico[]>(this.UrlPendentes)
  }
  getLisMontagemNFinalizados(): Observable<Montagem[]> {
    return this.http.get<Montagem[]>(this.UrlPendentesMont)
  }

}
