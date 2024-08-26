import { Component, OnInit } from '@angular/core';
import { Servico } from 'src/app/Models/ServicoMode';
//import { Servico } from '../Models/ServicoMode';
import { ServicoService } from 'src/app/Services/filtro-servico.service';
import { DatePipe } from '@angular/common';
//import { ServicoService } from '../Services/filtro-servico.service';

@Component({
  selector: 'app-servico-list',
  templateUrl: './servico-list.component.html',
    styleUrls: ['./servico-list.component.scss'],
    providers: [DatePipe]
    
})
export class ServicoListComponent implements OnInit {
  
  Servico: Servico[] = [];
  searchTerm: string = '';
  filteredServicos: Servico[] = [];

  constructor(private datapipe: DatePipe, public servicoServices: ServicoService) {}
  

  ngOnInit(): void {
    this.getAllServicos();
  }
  formatarData(data: Date | string): string {
    return this.datapipe.transform(data, 'dd/MM/yyyy') || '';
  }

  getAllServicos(): void {
    this.servicoServices.getallServicos().subscribe(res => {
      this.Servico = res;
      this.filteredServicos = this.Servico; // Inicialmente, mostrar todos os serviços
    });
  }

  filterServicos(): void {
    const term = this.searchTerm.toLowerCase();
    this.filteredServicos = this.Servico.filter(servico =>
      (servico.dataServico?.toLowerCase().includes(term) || '') ||
      (servico.mecanico?.toLowerCase().includes(term) || '')
    );
  }
}
