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
  const veiculotrim = this.veiculoPlaca.trim()
  
this.FiltroServices.getVeiculoByPlaca(veiculotrim).subscribe(res =>{
   this.Veiculo = res},
   err => {alert("Não foram encontrados veículos com essa placa")
    
  
   }
   
)
}
GetveiculoByChassi(){
  const veiculochassitrim = this.veiculoChassi.trim()
  this.FiltroServices.getVeiculoBychassi(veiculochassitrim).subscribe(res =>{
     this.Veiculo = res},
     err =>{alert("Não foram encontrados veículos com o chassi informado")}
    
    
    )
  }
}
