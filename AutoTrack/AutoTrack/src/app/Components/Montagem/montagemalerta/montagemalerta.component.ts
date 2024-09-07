import { Component } from '@angular/core';
import { Montagem } from 'src/app/Models/MontagemModel';
import { NotificacaoService } from 'src/app/Services/notificacao.service';

@Component({
  selector: 'app-montagemalerta',
  templateUrl: './montagemalerta.component.html',
  styleUrls: ['./montagemalerta.component.scss']
})
export class MontagemalertaComponent {

  Montagem : Montagem[] = []

  
  itemsPerPage: number = 3; 
  currentPage: number = 1; 
  totalItems: number = this.Montagem.length

  constructor(public montagemalerta : NotificacaoService) {
  
    
  }

  ngOnInit(): void {
    this.getmontnaopagos()
  }
  getmontnaopagos(){
    this.montagemalerta.getListMontNaoPagos().subscribe(res => this.Montagem = res)
  }
}
