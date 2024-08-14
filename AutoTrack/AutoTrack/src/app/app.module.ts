import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Components/Layout/header/header.component';
import { SidebarComponent } from './Components/Layout/sidebar/sidebar.component';
import { CardComponent } from './Components/Layout/card/card.component';
import { FooterComponent } from './Components/Layout/footer/footer.component';
import { ClienteComponent } from './Components/Cliente/cliente.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { VeiculoComponent } from './veiculo/veiculo.component';
import { ServicoComponent } from './servico/servico.component';
import { MontagemComponent } from './montagem/montagem.component';
import { ClientePostComponent } from './Components/Cliente-post/cliente-post.component';
import { VeiculoPostComponent } from './veiculo-post/veiculo-post.component';
import { ServicoPostComponent } from './servico-post/servico-post.component';
import { MontagemPostComponent } from './montagem-post/montagem-post.component';



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
  
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
