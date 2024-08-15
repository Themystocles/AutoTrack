import { Component, OnInit } from '@angular/core';
import { Veiculo } from '../Models/VeiculoModel';
import { FiltroVeiculoService } from '../Services/filtro-veiculo.service';
import { VeiculoPutService } from '../Services/CRUD - Cliente/veiculo-put.service';

@Component({
  selector: 'app-veiculo-list',
  templateUrl: './veiculo-list.component.html',
  styleUrls: ['./veiculo-list.component.scss']
})
export class VeiculoListComponent implements OnInit{

  Veiculo: Veiculo[] = [];
  searchTerm: string = '';
  filteredVeiculo: Veiculo[] = [];

  constructor(public VeiculoServices: FiltroVeiculoService) {}

  ngOnInit(): void {
    this.GetAllVeiculos();
  }

  GetAllVeiculos(): void {
    this.VeiculoServices.getAllVeiculos().subscribe(res => {
      this.Veiculo = res;
      this.filteredVeiculo = this.Veiculo; // Inicialmente, mostrar todos os clientes
    });
  }

  filterClientes(): void {
    const term = this.searchTerm.toLowerCase();
    this.filteredVeiculo = this.Veiculo.filter(Veiculo =>
      (Veiculo.placa?.toLowerCase().includes(term) || '') ||
      (Veiculo.chassi?.includes(term) || '') 
    );
  }
}




