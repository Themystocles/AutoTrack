import { Component, OnInit } from '@angular/core';
import { Servico } from 'src/app/Models/ServicoMode';
import { ServicoService } from 'src/app/Services/filtro-servico.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-servico-list',
  templateUrl: './servico-list.component.html',
  styleUrls: ['./servico-list.component.scss'],
  providers: [DatePipe]
})
export class ServicoListComponent implements OnInit {
  
  Servico: Servico[] = [];
  filteredServicos: Servico[] = [];
  selectedTipo: string = '';
  selectedData: string = '';

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
      this.filterServicos(); // Inicialmente, aplicar filtros padrão
    });
  }

  filterServicos(): void {
    this.filteredServicos = this.Servico.filter(servico => {
      const matchesTipo = this.selectedTipo ? servico.requalificacao?.toLowerCase() === this.selectedTipo.toLowerCase() : true;
      const matchesData = this.selectedData ? (servico.dataServico ? this.formatarData(servico.dataServico) === this.formatarData(this.selectedData) : false) : true;
      return matchesTipo && matchesData;
    });
  }
}
