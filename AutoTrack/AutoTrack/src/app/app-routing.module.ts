import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientePostComponent } from './Components/Cliente/Cliente-post/cliente-post.component';
import { VeiculoComponent } from './Components/Veiculo/veiculo/veiculo.component';
import { ServicoPostService } from './Services/CRUD - Cliente/servico-post.service';
import { ServicoPostComponent } from './Components/Servico/servico-post/servico-post.component';
import { MontagemPostService } from './Services/CRUD - Cliente/montagem-post.service';
import { MontagemPostComponent } from './Components/Montagem/montagem-post/montagem-post.component';
import { ClienteListComponent } from './Components/Cliente/cliente-list/cliente-list.component';
import { VeiculoPutComponent } from './Components/Veiculo/veiculo-put/veiculo-put.component';
import { ServicoPutComponent } from './Components/Servico/servico-put/servico-put.component';
import { ClientePutComponent } from './Components/Cliente/cliente-put/cliente-put.component';
import { VeiculoListComponent } from './Components/Veiculo/veiculo-list/veiculo-list.component';
import { VeiculoPostComponent } from './Components/Veiculo/veiculo-post/veiculo-post.component';
import { ServicoListComponent } from './Components/Servico/servico-list/servico-list.component';
import { MontagemListComponent } from './Components/Montagem/montagem-list/montagem-list.component';
import { MontagemPutComponent } from './Components/Montagem/montagem-put/montagem-put.component';
import { AlertaComponent } from './alerta/alerta.component';
import { MontagemalertaComponent } from './Components/Montagem/montagemalerta/montagemalerta.component';
import { PrintComponent } from './print/print.component';
import { SelecionarprintComponent } from './selecionarprint/selecionarprint.component';
import { PrintMontComponent } from './print-mont/print-mont.component';
import { RelatoriofinanceiroComponent } from './relatoriofinanceiro/relatoriofinanceiro.component';
import { EstoqueComponent } from './Components/estoque/estoque.component';
import { FolhadepagamentoComponent } from './folhadepagamento/folhadepagamento.component';


const routes: Routes = [
  
  { path: 'cliente-post', component: ClientePostComponent },
  { path: 'cliente-list', component: ClienteListComponent },
  { path: 'cliente-put/:id', component: ClientePutComponent },
  { path: 'veiculo-post', component: VeiculoPostComponent },
  { path: 'veiculo-list', component: VeiculoListComponent },
  { path: 'veiculo-put/:id', component: VeiculoPutComponent },
  { path: 'servico-post', component: ServicoPostComponent },
  { path: 'servico-list', component: ServicoListComponent },
  { path: 'servico-put/:id', component: ServicoPutComponent },
  { path: 'servico-notificacao', component: AlertaComponent},
  { path: 'montagem-post', component: MontagemPostComponent },
  { path: 'montagem-list', component: MontagemListComponent },
  { path: 'montagem-put/:id', component: MontagemPutComponent},
  { path: 'montagem-notificacao', component: MontagemalertaComponent},
  { path: 'imprimir', component: SelecionarprintComponent},
  { path: 'imprimir/Serv', component: PrintComponent },
  { path: 'imprimir/Mont', component: PrintMontComponent},
  { path: 'relatoriofinanceiro', component: RelatoriofinanceiroComponent},
  { path: 'estoque', component: EstoqueComponent},
  { path: 'estoque/:id', component: EstoqueComponent},
  { path: 'folhadepagamento', component: FolhadepagamentoComponent},


 
  
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
