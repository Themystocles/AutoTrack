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
    const now = new Date();
  
    // Ajusta a data para o fuso horário local removendo o deslocamento do UTC
    const localDate = new Date(now.getTime() - (now.getTimezoneOffset() * 60000))
      .toISOString()
      .split('T')[0];  // Pega apenas a parte da data (YYYY-MM-DD)
  
    this.date = localDate;
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



