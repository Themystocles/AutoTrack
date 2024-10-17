import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { RelatorioFinanceiroService } from 'src/app/Services/CRUD - Cliente/relatorio-financeiro.service';

@Component({
  selector: 'app-relatoriofinanceiro',
  templateUrl: './relatoriofinanceiro.component.html',
  styleUrls: ['./relatoriofinanceiro.component.scss']
})
export class RelatoriofinanceiroComponent implements OnInit {


  datainicio!: Date
  dataFim!: Date
  relPagoTotalPeriodo: number = 0;
  creditoPago: number = 0;
  debitoPago: number = 0;
  dinheiroPago: number = 0;
  pixPago: number = 0;

  relNaoPagoTotalPeriodo: number = 0;
  creditoNaoPago: number = 0;
  debitoNaoPago: number = 0;
  dinheiroNaoPago: number = 0;
  pixNaoPago: number = 0;

  relMonPagoTotalPeriodo: number = 0;
  creditoMonPago: number = 0;
  debitoMonPago: number = 0;
  dinheiroMonPago: number = 0;
  pixMonPago: number = 0;

  relMonNaoPagoTotalPeriodo: number = 0;
  creditoMonNaoPago: number = 0;
  debitoMonNaoPago: number = 0;
  dinheiroMonNaoPago: number = 0;
  pixMonNaoPago: number = 0;

  constructor(public relatorioservices: RelatorioFinanceiroService, private router: Router) { }

  ngOnInit(): void {

  }

  public loadRelatorios(): void {
    this.relatorioservices.getRelatorioPago(this.datainicio, this.dataFim).subscribe(res => this.relPagoTotalPeriodo = res);
    this.relatorioservices.getCreditopago(this.datainicio, this.dataFim).subscribe(res => this.creditoPago = res);
    this.relatorioservices.getDebitoPago(this.datainicio, this.dataFim).subscribe(res => this.debitoPago = res);
    this.relatorioservices.getDinheiroPago(this.datainicio, this.dataFim).subscribe(res => this.dinheiroPago = res);
    this.relatorioservices.getPixPago(this.datainicio, this.dataFim).subscribe(res => this.pixPago = res);

    this.relatorioservices.getRelatorioNaoPago(this.datainicio, this.dataFim).subscribe(res => this.relNaoPagoTotalPeriodo = res);
    this.relatorioservices.getCreditoNaoPago(this.datainicio, this.dataFim).subscribe(res => this.creditoNaoPago = res);
    this.relatorioservices.getDebitoNaoPago(this.datainicio, this.dataFim).subscribe(res => this.debitoNaoPago = res);
    this.relatorioservices.getDinheiroNaoPago(this.datainicio, this.dataFim).subscribe(res => this.dinheiroNaoPago = res);
    this.relatorioservices.getPixNaoPago(this.datainicio, this.dataFim).subscribe(res => this.pixNaoPago = res);

    this.relatorioservices.getRelatorioMonPago(this.datainicio, this.dataFim).subscribe(res => this.relMonPagoTotalPeriodo = res);
    this.relatorioservices.getCreditoMonPago(this.datainicio, this.dataFim).subscribe(res => this.creditoMonPago = res);
    this.relatorioservices.getDebitoMonPago(this.datainicio, this.dataFim).subscribe(res => this.debitoMonPago = res);
    this.relatorioservices.getDinheiroMonPago(this.datainicio, this.dataFim).subscribe(res => this.dinheiroMonPago = res);
    this.relatorioservices.getPixMonPago(this.datainicio, this.dataFim).subscribe(res => this.pixMonPago = res);

    this.relatorioservices.getRelatorioMonNaoPago(this.datainicio, this.dataFim).subscribe(res => this.relMonNaoPagoTotalPeriodo = res);
    this.relatorioservices.getCreditoMonNaoPago(this.datainicio, this.dataFim).subscribe(res => this.creditoMonNaoPago = res);
    this.relatorioservices.getDebitoMonNaoPago(this.datainicio, this.dataFim).subscribe(res => this.debitoMonNaoPago = res);
    this.relatorioservices.getDinheiroMonNaoPago(this.datainicio, this.dataFim).subscribe(res => this.dinheiroMonNaoPago = res);
    this.relatorioservices.getPixMonNaoPago(this.datainicio, this.dataFim).subscribe(res => this.pixMonNaoPago = res);



  }
  imprimirRelatorio() {
    // Supondo que você tenha `datainicio` e `dataFim` como filtros
    this.router.navigate(['/printFinanceiro'], {
      queryParams: {
        datainicio: this.datainicio,
        dataFim: this.dataFim
      }
    });
  }

}
