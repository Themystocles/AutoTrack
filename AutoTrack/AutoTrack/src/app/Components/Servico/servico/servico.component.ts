import { Component, OnInit } from '@angular/core';
import { ServicoService } from '../../../Services/filtro-servico.service';
import { Servico } from '../../../Models/ServicoMode';
import { Veiculo } from '../../../Models/VeiculoModel';
import { valtot } from 'src/app/Models/ValTot';

@Component({
  selector: 'app-servico',
  templateUrl: './servico.component.html',
  styleUrls: ['./servico.component.scss']
})
export class ServicoComponent implements OnInit{
  servdata! : string
  servico : Servico[] = [];
  valtot : valtot[] = []
  
  constructor(public servicoservice : ServicoService) {}

ngOnInit(): void {
  this.getOrcTot()
}
  GetServicoByData(){
    
    this.servicoservice.getservicobydate(this.servdata).subscribe(res =>{
       this.servico = res},
       
      err=> {this.servico = [];
      alert("Não há serviço na data selecionada")
        
      },
      
      )
      
    }
    getOrcTot(){
      this.servicoservice.getValTot().subscribe(res => { 
        this.valtot = res
      }
      
      )
    }

    

}
