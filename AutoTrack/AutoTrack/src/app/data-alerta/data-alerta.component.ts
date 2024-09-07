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
    this.date = new Date().toISOString(); // Formato ISO 8601
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
