import { Component, OnInit } from '@angular/core';


import { Servico } from 'src/app/Models/ServicoMode';
import { NotificacaoService } from 'src/app/Services/notificacao.service';

@Component({
  selector: 'app-pendentes',
  templateUrl: './pendentes.component.html',
  styleUrls: ['./pendentes.component.scss']
})
export class PendentesComponent implements OnInit {
  servico: Servico[] = [];
  filteredServicos: Servico[] = []; // Serviços filtrados
  searchTerm: string = ''; // Termo de busca

  constructor(public serviçoalerta: NotificacaoService) { }

  ngOnInit(): void {
    this.getservicosnaoPagos();
  }

  filterServicos() {
    const term = this.searchTerm.toLowerCase();
    this.filteredServicos = this.servico.filter(serv => {
      return (
        serv.veiculo?.cliente?.nome?.toLowerCase().includes(term) || // Filtra pelo nome do cliente
        serv.veiculo?.placa?.toLowerCase().includes(term) // Filtra pela placa do veículo
      );
    });
  }

  getservicosnaoPagos() {
    this.serviçoalerta.getLisServicosNFinalizados().subscribe(res => {
      this.servico = res;
      this.filteredServicos = res; // Atualiza os serviços filtrados com os dados recebidos
    });
  }
}
