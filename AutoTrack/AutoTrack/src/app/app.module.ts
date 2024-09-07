import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Components/Layout/header/header.component';
import { SidebarComponent } from './Components/Layout/sidebar/sidebar.component';
import { CardComponent } from './Components/Layout/card/card.component';
import { FooterComponent } from './Components/Layout/footer/footer.component';
import { ClienteComponent } from './Components/Cliente/Cliente/cliente.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { VeiculoComponent } from './Components/Veiculo/veiculo/veiculo.component';
import { ServicoComponent } from './Components/Servico/servico/servico.component';
//import { MontagemComponent } from './montagem/montagem.component';
import { ClientePostComponent } from './Components/Cliente/Cliente-post/cliente-post.component';
//import { VeiculoPostComponent } from './veiculo-post/veiculo-post.component';
import { ServicoPostComponent } from './Components/Servico/servico-post/servico-post.component';
import { MontagemPostComponent } from './Components/Montagem/montagem-post/montagem-post.component';
import { ClienteListComponent } from './Components/Cliente/cliente-list/cliente-list.component';
import { ClientePutComponent } from './Components/Cliente/cliente-put/cliente-put.component';
//import { VeiculoListComponent } from './veiculo-list/veiculo-list.component';
import { VeiculoPutComponent } from './Components/Veiculo/veiculo-put/veiculo-put.component';
//import { ServicoListComponent } from './servico-list/servico-list.component';
//import { MontagemListComponent } from './montagem-list/montagem-list.component';
import { ServicoPutComponent } from './Components/Servico/servico-put/servico-put.component';
//import { MontagemPutComponent } from './montagem-put/montagem-put.component';
import { OrcamentoListComponent } from './Components/Orcamento/orcamento-list/orcamento-list.component';
import { OrcamentoPostComponent } from './Components/Orcamento/orcamento-post/orcamento-post.component';
import { VeiculoListComponent } from './Components/Veiculo/veiculo-list/veiculo-list.component';
import { VeiculoPostComponent } from './Components/Veiculo/veiculo-post/veiculo-post.component';
import { ServicoListComponent } from './Components/Servico/servico-list/servico-list.component';
import { MontagemComponent } from './Components/Montagem/montagem/montagem.component';
import { MontagemListComponent } from './Components/Montagem/montagem-list/montagem-list.component';
import { MontagemPutComponent } from './Components/Montagem/montagem-put/montagem-put.component';
import { DatePipe } from '@angular/common';
import { NgxMaskModule } from 'ngx-mask';
import { AlertaComponent } from './alerta/alerta.component';
import { MontagemalertaComponent } from './Components/Montagem/montagemalerta/montagemalerta.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { PrintComponent } from './print/print.component';
import { DataAlertaComponent } from './data-alerta/data-alerta.component';
import { SelecionarprintComponent } from './selecionarprint/selecionarprint.component';
import { PrintMontComponent } from './print-mont/print-mont.component';





@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SidebarComponent,
    CardComponent,
    FooterComponent,
    ClienteComponent,
    VeiculoComponent,
    ServicoComponent,
    MontagemComponent,
    ClientePostComponent,
    VeiculoPostComponent,
    ServicoPostComponent,
    MontagemPostComponent,
    ClienteListComponent,
    ClientePutComponent,
    VeiculoListComponent,
    VeiculoPutComponent,
    ServicoListComponent,
    MontagemListComponent,
    ServicoPutComponent,
    MontagemPutComponent,
    OrcamentoListComponent,
    OrcamentoPostComponent,
    AlertaComponent,
    MontagemalertaComponent,
    PrintComponent,
    DataAlertaComponent,
    SelecionarprintComponent,
    PrintMontComponent,
 
    
   
    
  
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgxMaskModule.forRoot(),
    NgxPaginationModule
    
    
    
    
    
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
