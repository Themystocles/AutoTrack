import { Component } from '@angular/core';
import { Montagem } from '../Models/MontagemModel';
import { MontagemService } from '../Services/filtro-montagem.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-data-alerta-montagem',
  templateUrl: './data-alerta-montagem.component.html',
  styleUrls: ['./data-alerta-montagem.component.scss']
})
export class DataAlertaMontagemComponent {
  montagem: Montagem[] = [];
  date: string = '';
  showDetails: boolean = false; // Variável para controlar a exibição dos detalhes
  showAlert: boolean = true; // Variável para controlar a exibição do alerta

  constructor(public montagemservices: MontagemService, private router: Router) { } // Injetar Router

  ngOnInit(): void {
    this.date = new Date().toISOString(); // Formato ISO 8601
    this.GetservByAlert();
  }

  GetservByAlert() {
    this.montagemservices.getMontagembydateAlert(this.date).subscribe(res => {
      this.montagem = res;
    });
  }

  toggleDetails() {
    this.showDetails = !this.showDetails;
  }

  closeDetails() {
    this.showDetails = false;
  }

  navigateToMont(MontId: number | undefined) {
    if (MontId !== undefined) {
      this.router.navigate(['/montagem-put', MontId]); // Usar Router para navegação
      this.closeDetails(); // Fecha o modal
      this.showAlert = false; // Esconde o alerta
    } else {
      console.error('ID do serviço é indefinido');
    }
  }
}



