import { Component } from '@angular/core';
import { ServicoService } from '../Services/filtro-servico.service';
import { Servico } from '../Models/ServicoMode';
import { Veiculo } from '../Models/VeiculoModel';

@Component({
  selector: 'app-servico',
  templateUrl: './servico.component.html',
  styleUrls: ['./servico.component.scss']
})
export class ServicoComponent {
  servdata! : string
  servico : Servico[] = [];


  constructor(public servicoservice : ServicoService) {
    
    
  }
  GetServicoByData(){
  
    this.servicoservice.getservicobydate(this.servdata).subscribe(res => this.servico = res)
    }

}
