import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Funcionario } from 'src/app/Models/Funcionario';
import { FuncionarioOrcamentosResponse } from 'src/app/Models/OrcamentoFuncionarioModel'; // Ajuste o caminho conforme necessário

@Injectable({
  providedIn: 'root'
})
export class FolhadepagamentoService {

  url = 'http://localhost:5203/api/OrcamentoFuncionario/funcionarioseOrcamentos';

  constructor(public http: HttpClient) { }

  private getReport(url: string, datainicio: Date, datafim: Date): Observable<FuncionarioOrcamentosResponse> {
    // Verifica se datainicio e datafim são objetos Date; caso contrário, converte
    const dataInicioDate = datainicio instanceof Date ? datainicio : new Date(datainicio);
    const dataFimDate = datafim instanceof Date ? datafim : new Date(datafim);

    const params = new HttpParams()
      .set('datainicio', dataInicioDate.toISOString().split('T')[0]) // Formato YYYY-MM-DD
      .set('datafim', dataFimDate.toISOString().split('T')[0]); // Formato YYYY-MM-DD

    return this.http.get<FuncionarioOrcamentosResponse>(url, { params });
  }

  getfuncionarioseorcamentos(datainicio: Date, datafim: Date): Observable<FuncionarioOrcamentosResponse> {
    return this.getReport(this.url, datainicio, datafim);
  }
 
}
