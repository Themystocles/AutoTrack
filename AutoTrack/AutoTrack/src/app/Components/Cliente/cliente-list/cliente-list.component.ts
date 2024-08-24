import { Component, OnInit } from '@angular/core';
import { FiltroServicesService } from '../../../Services/filtro-cliente.service';
import { Cliente } from '../../../Models/ClienteModel';

@Component({
  selector: 'app-cliente-list',
  templateUrl: './cliente-list.component.html',
  styleUrls: ['./cliente-list.component.scss']
})
export class ClienteListComponent implements OnInit {

  Cliente: Cliente[] = [];
  searchTerm: string = '';
  filteredClientes: Cliente[] = [];

  constructor(public ClienteServices: FiltroServicesService) {}

  ngOnInit(): void {
    this.GetAllClientes();
  }

  GetAllClientes(): void {
    this.ClienteServices.getAllClientes().subscribe(res => {
      this.Cliente = res;
      this.filteredClientes = this.Cliente; // Inicialmente, mostrar todos os clientes
    });
  }

  filterClientes(): void {
    const term = this.searchTerm.toLowerCase();
    this.filteredClientes = this.Cliente.filter(cliente =>
      (cliente.nome?.toLowerCase().includes(term) || '') ||
      (cliente.cpf?.includes(term) || '') ||
      (cliente.telefone?.includes(term) || '')
    );
  }
}
