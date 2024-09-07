import { Component, OnInit } from '@angular/core';
import { NgModel } from '@angular/forms';
import { empty } from 'rxjs';
import { Cliente } from 'src/app/Models/ClienteModel';
import { Veiculo } from 'src/app/Models/VeiculoModel';
import { FiltroServicesService } from 'src/app/Services/filtro-cliente.service';



@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent implements OnInit {
  CPForCNPJ: string = "";
  Telefone: string = "";
  Nome: string = "";
  Cliente!: Cliente;
  searchResults: Cliente[] = []; // Para armazenar os resultados da pesquisa

  constructor(public FiltroServices: FiltroServicesService) { }

  ngOnInit(): void {
    // Inicializa o Cliente e limpa a lista de resultados
    this.Cliente = new Cliente();
    this.Cliente.veiculos = [];
  }

  GetClienteByCPForCNPJ() {
    const CPFCNPJTrim = this.CPForCNPJ.trim()
    this.FiltroServices.getClientByCpf(CPFCNPJTrim).subscribe(
      res => {
        this.Cliente = res;
        this.searchResults = []; // Limpa os resultados da pesquisa
      },
      err => {
        console.error('Erro ao buscar cliente por CPF:', err);
        alert('Não existe cliente com esse CPF')
        this.Cliente = new Cliente(); // Limpa os dados do cliente
        this.searchResults = []; // Limpa os resultados da pesquisa
      }
    );
  }

  GetClienteByTelefone() {
    const TelefoneTrim = this.Telefone.trim()
    this.FiltroServices.getClientByTelefone(TelefoneTrim).subscribe(
      res => {
        this.Cliente = res;
        this.searchResults = []; // Limpa os resultados da pesquisa
      },
      err => {
        console.error('Erro ao buscar cliente por Telefone:', err);
        alert('Não existe cliente com esse Número de telefone')
        this.Cliente = new Cliente(); // Limpa os dados do cliente
        this.searchResults = []; // Limpa os resultados da pesquisa
      }
    );
  }

  GetClienteByNome() {
    const nomeTrim = this.Nome.trim()
    this.FiltroServices.getClientByNome(nomeTrim).subscribe(
      res => {
        this.searchResults = res;
        if(!res || res.length === 0){alert('O filtro não consegue encontrar um cliente com esse nome')}
        this.Cliente = new Cliente(); // Limpa os dados do cliente
      },
      err => {
        console.error('Erro ao buscar cliente por Nome:', err);
        alert('O filtro não consegue encontrar um cliente com esse nome')
        this.searchResults = [];
         // Limpa os resultados da pesquisa
      }
    );
  }

  selectCliente(cliente: Cliente) {
    this.Cliente = cliente;
    this.searchResults = []; // Limpa os resultados após a seleção
  }
}
