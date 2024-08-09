import { Component } from '@angular/core';


@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})


export class CardComponent {

  showCliente = false;
  showVeiculo = false;
  showServico = false;


  toggleCliente() {
    this.showCliente = !this.showCliente;
    this.showVeiculo = false;
    this.showServico = false;
  }
  toggleVeiculo() {
    this.showVeiculo = !this.showVeiculo;
    this.showCliente = false;
    this.showServico = false;
  }
  toggleServico() {
    this.showServico = !this.showServico;
    this.showCliente = false;
    this.showVeiculo = false;
  }
  

}


