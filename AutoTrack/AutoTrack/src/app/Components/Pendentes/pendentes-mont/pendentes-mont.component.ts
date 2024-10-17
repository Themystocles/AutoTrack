import { Component, OnInit } from '@angular/core';


import { Montagem } from 'src/app/Models/MontagemModel';
import { NotificacaoService } from 'src/app/Services/notificacao.service';

@Component({
  selector: 'app-pendentes-mont',
  templateUrl: './pendentes-mont.component.html',
  styleUrls: ['./pendentes-mont.component.scss']
})
export class PendentesMontComponent implements OnInit {
  Montagem: Montagem[] = [];
  filteredMontagens: Montagem[] = []; // Montagens filtradas
  searchTerm: string = ''; // Termo de busca

  constructor(public serviçoalerta: NotificacaoService) { }

  ngOnInit(): void {
    this.getMontagemNPagos();
  }

  // Função para buscar montagens não pagas
  getMontagemNPagos() {
    this.serviçoalerta.getLisMontagemNFinalizados().subscribe(res => {
      this.Montagem = res;
      this.filteredMontagens = res; // Inicializa a lista filtrada
    });
  }

  // Função para filtrar montagens
  filterMontagens() {
    const term = this.searchTerm.toLowerCase();
    this.filteredMontagens = this.Montagem.filter(mont => {
      return (
        mont.veiculo?.cliente?.nome?.toLowerCase().includes(term) || // Filtra pelo nome do cliente
        mont.veiculo?.placa?.toLowerCase().includes(term) // Filtra pela placa do veículo
      );
    });
  }
}
