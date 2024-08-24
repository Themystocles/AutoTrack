import { Component } from '@angular/core';
import { FiltroVeiculoService } from '../../../Services/filtro-veiculo.service';
import { Veiculo } from '../../../Models/VeiculoModel';

@Component({
  selector: 'app-veiculo',
  templateUrl: './veiculo.component.html',
  styleUrls: ['./veiculo.component.scss']
})
export class VeiculoComponent {
  veiculoPlaca! : string;
  veiculoChassi! : string;

  Veiculo! : Veiculo;

  
  constructor(public FiltroServices : FiltroVeiculoService) {
   
    
  }

  

GetveiculoByPlaca(){
  
this.FiltroServices.getVeiculoByPlaca(this.veiculoPlaca).subscribe(res => this.Veiculo = res)
}
GetveiculoByChassi(){
  
  this.FiltroServices.getVeiculoBychassi(this.veiculoChassi).subscribe(res => this.Veiculo = res)
  }
}
