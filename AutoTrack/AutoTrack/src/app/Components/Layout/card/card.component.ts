import { Component } from '@angular/core';


@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})


export class CardComponent {

  showCliente = false;
  showVeiculo = false;

  toggleCliente() {
    this.showCliente = !this.showCliente;
    this.showVeiculo = false;
  }
  toggleVeiculo() {
    this.showVeiculo = !this.showVeiculo;
    this.showCliente = false;
  }
  

}


