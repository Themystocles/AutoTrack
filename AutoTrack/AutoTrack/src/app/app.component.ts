import { Component } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'AutoTrack';
  showCard = true;
  showHeaderFooterSidebar = true;

  constructor(private router: Router) {
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe(() => {
      const url = this.router.url;
      this.showCard = !this.isCardRoute(url);
      this.showHeaderFooterSidebar = !this.isPrintRoute(url);
    });
  }

  private isCardRoute(url: string): boolean {
    return url.includes('/cliente-post') || url.includes('/veiculo-post') || url.includes('/servico-post') || 
           url.includes('/montagem-post') || url.includes('/cliente-list') || url.includes('/cliente-put') || 
           url.includes('/veiculo-list') || url.includes('/veiculo-put') || url.includes('/servico-list') || 
           url.includes('/servico-put') || url.includes('/montagem-list') || url.includes('/montagem-put') || 
           url.includes('/servico-notificacao') || url.includes('/montagem-notificacao') || url.includes('relatoriofinanceiro')
          || url.includes('estoque')|| url.includes('folhadepagamento')|| url.includes('funcionarios')|| url.includes('funcionarioput')
          || url.includes('funcionariopost');
  }

  private isPrintRoute(url: string): boolean {
    return url === '/imprimir' || url === '/imprimir/Serv' || url === '/imprimir/Mont';
}
}
