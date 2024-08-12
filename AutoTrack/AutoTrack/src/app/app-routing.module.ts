import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientePostComponent } from './Components/Cliente-post/cliente-post.component';
import { VeiculoComponent } from './veiculo/veiculo.component';
import { VeiculoPostComponent } from './veiculo-post/veiculo-post.component';

const routes: Routes = [
  { path: 'cliente-post', component: ClientePostComponent },
  { path: 'veiculo-post', component: VeiculoPostComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
