import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientePostComponent } from './Components/Cliente-post/cliente-post.component';
import { VeiculoComponent } from './veiculo/veiculo.component';
import { VeiculoPostComponent } from './veiculo-post/veiculo-post.component';
import { ServicoPostService } from './Services/CRUD - Cliente/servico-post.service';
import { ServicoPostComponent } from './servico-post/servico-post.component';
import { MontagemPostService } from './Services/CRUD - Cliente/montagem-post.service';
import { MontagemComponent } from './montagem/montagem.component';
import { MontagemPostComponent } from './montagem-post/montagem-post.component';

const routes: Routes = [
  { path: 'cliente-post', component: ClientePostComponent },
  { path: 'veiculo-post', component: VeiculoPostComponent },
  { path: 'servico-post', component: ServicoPostComponent },
  { path: 'montagem-post', component: MontagemPostComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
