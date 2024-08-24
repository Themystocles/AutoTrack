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

  constructor(private router: Router) {
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe(() => {
      this.showCard = !this.isCardRoute(this.router.url);
    });
  }


  private isCardRoute(url: string): boolean {
    return url.includes('/cliente-post')|| url.includes('/veiculo-post') || url.includes('/servico-post') || url.includes('/montagem-post')
    || url.includes('/cliente-list') || url.includes('/cliente-put')|| url.includes('/veiculo-list') || url.includes('/veiculo-put')|| url.includes('/servico-list') 
    || url.includes('/servico-put') || url.includes('/montagem-list') || url.includes('/montagem-put')
  }
}
