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

  // Define as rotas nas quais o app-card deve desaparecer
  private isCardRoute(url: string): boolean {
    return url.includes('/cliente-post')|| url.includes('/veiculo-post') || url.includes('/servico-post') || url.includes('/montagem-post'); // Substitua com a rota que deve esconder o app-card
  }
}
