import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RelatorioFinanceiroService {
  // URLs dos serviços
  Relatoriopago = "http://localhost:5203/api/RelatorioFinanceiro/relatoriofinanceiro";
  creditopago = "http://localhost:5203/api/RelatorioFinanceiro/Credito";
  debitopago = "http://localhost:5203/api/RelatorioFinanceiro/Débito";
  dinheiropago = "http://localhost:5203/api/RelatorioFinanceiro/Dinheiro";
  pixpago = "http://localhost:5203/api/RelatorioFinanceiro/Pix";

  Relatorionpago = "http://localhost:5203/api/RelatorioFinanceiro/relatoriofinanceironaopago";
  creditonpago = "http://localhost:5203/api/RelatorioFinanceiro/CreditoNPago";
  debitonpago = "http://localhost:5203/api/RelatorioFinanceiro/DébitoNPago";
  dinheironpago = "http://localhost:5203/api/RelatorioFinanceiro/DinheiroNPago";
  pixnpago = "http://localhost:5203/api/RelatorioFinanceiro/PixNpago";

  // Montagem
  Relatorimontopago = "http://localhost:5203/api/RelatorioFinanceiro/relatorioMonfinanceiro";
  creditomontpago = "http://localhost:5203/api/RelatorioFinanceiro/CreditoMon";
  debitomontpago = "http://localhost:5203/api/RelatorioFinanceiro/DébitoMon";
  dinheiromontpago = "http://localhost:5203/api/RelatorioFinanceiro/DinheiroMon";
  pixmontpago = "http://localhost:5203/api/RelatorioFinanceiro/PixMon";

  Relatoriomontnpago = "http://localhost:5203/api/RelatorioFinanceiro/relatorioMonfinanceironaopago";
  creditomontnpago = "http://localhost:5203/api/RelatorioFinanceiro/CreditoMonNPago";
  debitomontnpago = "http://localhost:5203/api/RelatorioFinanceiro/DébitoMonNPago";
  dinheiromontnpago = "http://localhost:5203/api/RelatorioFinanceiro/DinheiroMonNPago";
  pixmontnpago = "http://localhost:5203/api/RelatorioFinanceiro/PixMonNpago";

  constructor(public http: HttpClient) { }

  private getReport(url: string, datainicio: any, datafim: any): Observable<number> {
    // Verifica se datainicio e datafim são objetos Date; caso contrário, converte
    const dataInicioDate = datainicio instanceof Date ? datainicio : new Date(datainicio);
    const dataFimDate = datafim instanceof Date ? datafim : new Date(datafim);
  
    const params = new HttpParams()
      .set('datainicio', dataInicioDate.toISOString().split('T')[0]) // Formato YYYY-MM-DD
      .set('datafim', dataFimDate.toISOString().split('T')[0]); // Formato YYYY-MM-DD
  
    return this.http.get<number>(url, { params });
  }

  getRelatorioPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.Relatoriopago, datainicio, datafim);
  }

  getCreditopago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.creditopago, datainicio, datafim);
  }

  getDebitoPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.debitopago, datainicio, datafim);
  }

  getDinheiroPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.dinheiropago, datainicio, datafim);
  }

  getPixPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.pixpago, datainicio, datafim);
  }

  getRelatorioNaoPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.Relatorionpago, datainicio, datafim);
  }

  getCreditoNaoPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.creditonpago, datainicio, datafim);
  }

  getDebitoNaoPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.debitonpago, datainicio, datafim);
  }

  getDinheiroNaoPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.dinheironpago, datainicio, datafim);
  }

  getPixNaoPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.pixnpago, datainicio, datafim);
  }

  getRelatorioMonPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.Relatorimontopago, datainicio, datafim);
  }

  getCreditoMonPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.creditomontpago, datainicio, datafim);
  }

  getDebitoMonPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.debitomontpago, datainicio, datafim);
  }

  getDinheiroMonPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.dinheiromontpago, datainicio, datafim);
  }

  getPixMonPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.pixmontpago, datainicio, datafim);
  }

  getRelatorioMonNaoPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.Relatoriomontnpago, datainicio, datafim);
  }

  getCreditoMonNaoPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.creditomontnpago, datainicio, datafim);
  }

  getDebitoMonNaoPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.debitomontnpago, datainicio, datafim);
  }

  getDinheiroMonNaoPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.dinheiromontnpago, datainicio, datafim);
  }

  getPixMonNaoPago(datainicio: Date, datafim: Date): Observable<number> {
    return this.getReport(this.pixmontnpago, datainicio, datafim);
  }
}
