import { Component, OnInit } from '@angular/core';
import { Subscriber } from 'rxjs';
import { NotificacaoService } from 'src/app/Services/notificacao.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit{

  notificacaoServ : number = 0;
  notificacaoMont : number = 0;

 
  constructor(public notificacaoservices : NotificacaoService) {}

  ngOnInit(): void {
    this.getservnpago()
    this.getmontnpagp()
  }

  getservnpago(){
    this.notificacaoservices.getQtdNaoPago().subscribe(res => this.notificacaoServ = res)
  }
  getmontnpagp(){
    this.notificacaoservices.getQtdMontNaoPago().subscribe(res => this.notificacaoMont = res)
  }

}
