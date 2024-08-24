import { Component } from '@angular/core';
import { Montagem } from 'src/app/Models/MontagemModel';
import { MontagemService } from 'src/app/Services/filtro-montagem.service';
//import { Montagem } from '../Models/MontagemModel';
//import { MontagemService } from '../Services/filtro-montagem.service';

@Component({
  selector: 'app-montagem',
  templateUrl: './montagem.component.html',
  styleUrls: ['./montagem.component.scss']
})
export class MontagemComponent {
  montDate! : string
  montagem : Montagem[] = [];


  constructor(public montagemService : MontagemService) {
    
    
  }
  GetMontagemByDate(){
  
    this.montagemService.getMontagembydate(this.montDate).subscribe(res => this.montagem = res)
    }

}

