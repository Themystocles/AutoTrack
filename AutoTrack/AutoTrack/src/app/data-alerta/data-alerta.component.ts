import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'; // Importar Router
import { Servico } from '../Models/ServicoMode';
import { ServicoService } from '../Services/filtro-servico.service';

@Component({
  selector: 'app-data-alerta',
  templateUrl: './data-alerta.component.html',
  styleUrls: ['./data-alerta.component.scss']
})
export class DataAlertaComponent implements OnInit {

  servico: Servico[] = [];
  date: string = '';
  showDetails: boolean = false; // Variável para controlar a exibição dos detalhes
  showAlert: boolean = true; // Variável para controlar a exibição do alerta

  constructor(public servicoservices: ServicoService, private router: Router) { } // Injetar Router

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
    this.servicoservices.getservicobydateAlert(this.date).subscribe(res => {
      this.servico = res;
    });
  }

  toggleDetails() {
    this.showDetails = !this.showDetails;
  }

  closeDetails() {
    this.showDetails = false;
  }

  navigateToServico(servicoId: number | undefined) {
    if (servicoId !== undefined) {
      this.router.navigate(['/servico-put', servicoId]); // Usar Router para navegação
      this.closeDetails(); // Fecha o modal
      this.showAlert = false; // Esconde o alerta
    } else {
      console.error('ID do serviço é indefinido');
    }
  }
}
