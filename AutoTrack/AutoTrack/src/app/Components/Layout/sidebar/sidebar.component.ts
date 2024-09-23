import { Component, OnInit } from '@angular/core';
import { Estoque } from 'src/app/Models/EstoqueModel';
import { CrudEstoqueService } from 'src/app/Services/CRUD - Cliente/crud-estoque.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

 ItensMinimo : Estoque[] = []
 showTooltip = false;
  
  constructor(public estoqueServices : CrudEstoqueService) {}

  ngOnInit(): void {

    this.estoqueminimo()
    
  }

  estoqueminimo(){
    this.estoqueServices.getAlerta().subscribe(res => this.ItensMinimo = res)
  }


}
