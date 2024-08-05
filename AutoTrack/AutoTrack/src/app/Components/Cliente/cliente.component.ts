import { Component, OnInit } from '@angular/core';
import { Cliente } from 'src/app/Models/ClienteModel';
import { FiltroServicesService } from 'src/app/Services/filtro-services.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent implements OnInit {
  CPForCNPJ: string = "";
  Cliente! : Cliente;

  constructor(public FiltroServices : FiltroServicesService) {
  
    
  }
  ngOnInit(): void {
    this.GetClienteByCPForCNPJ()
    
  }

  GetClienteByCPForCNPJ(){
  
   this.FiltroServices.getClientByCpf(this.CPForCNPJ).subscribe(res => this.Cliente = res)
  }
}
