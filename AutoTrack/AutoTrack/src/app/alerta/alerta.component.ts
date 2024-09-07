import { Component, OnInit } from '@angular/core';
import { NotificacaoService } from '../Services/notificacao.service';
import { Servico } from '../Models/ServicoMode';

@Component({
  selector: 'app-alerta',
  templateUrl: './alerta.component.html',
  styleUrls: ['./alerta.component.scss']
})
export class AlertaComponent implements OnInit{

  servico : Servico[] = []
  itemsPerPage: number = 3; 
  currentPage: number = 1; 
  totalItems: number = this.servico.length

  constructor(public serviçoalerta : NotificacaoService) {
  
    
  }

  ngOnInit(): void {
    this.getservicosnaoPagos()
  }
  getservicosnaoPagos(){
    this.serviçoalerta.getListNaoPagos().subscribe(res => this.servico = res)
  }
  

  

}
