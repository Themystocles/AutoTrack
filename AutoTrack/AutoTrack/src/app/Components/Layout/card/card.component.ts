import { Component } from '@angular/core';


@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})


export class CardComponent {

  showCliente = false;

  toggleCliente() {
    this.showCliente = !this.showCliente;
  }
  

}


