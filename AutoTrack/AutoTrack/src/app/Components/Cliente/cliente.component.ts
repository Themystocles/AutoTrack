import { Component, OnInit } from '@angular/core';
import { Cliente } from 'src/app/Models/ClienteModel';
import { Veiculo } from 'src/app/Models/VeiculoModel';
import { FiltroServicesService } from 'src/app/Services/filtro-services.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent implements OnInit {
  CPForCNPJ: string = "";
  Telefone: string = "";
  Nome: string = "";
  veiculo: string = "";
  Cliente! : Cliente;
  Veiculo! : Veiculo[];

  constructor(public FiltroServices : FiltroServicesService) {
  
    
  }
  ngOnInit(): void {
    this.Cliente.veiculos = [];
    
  }

  GetClienteByCPForCNPJ(){
  
   this.FiltroServices.getClientByCpf(this.CPForCNPJ).subscribe(res => this.Cliente = res)
  }
  GetClienteByTelefone(){
  
    this.FiltroServices.getClientByTelefone(this.Telefone).subscribe(res => this.Cliente = res)
   }
   GetClienteByNome(){
  
    this.FiltroServices.getClientByNome(this.Nome).subscribe(res => this.Cliente = res)
   }
 
 
}
