import { Component, OnInit } from '@angular/core';
import { Montagem } from 'src/app/Models/MontagemModel';
import { MontagemService } from 'src/app/Services/filtro-montagem.service';
//import { Montagem } from '../Models/MontagemModel';
//import { MontagemService } from '../Services/filtro-montagem.service';

@Component({
  selector: 'app-montagem-list',
  templateUrl: './montagem-list.component.html',
  styleUrls: ['./montagem-list.component.scss']
})
export class MontagemListComponent implements OnInit{
  
  Montagem : Montagem[] = []
  searchTerm: string = '';
  filteredMontagens: Montagem[] = [];


  constructor(public MontagemServices : MontagemService) {}

  ngOnInit(): void {
    this.getAllMontagem()
    
  }
  getAllMontagem(): void {
    this.MontagemServices.getAllMontagem().subscribe(res => {
      this.Montagem = res;
      this.filteredMontagens = this.Montagem; // Inicialmente, mostrar todos os clientes
    });
  }
  filterMontagens(): void {
    const term = this.searchTerm.toLowerCase();
    this.filteredMontagens = this.Montagem.filter(Montagem =>
      (Montagem.data?.toLowerCase().includes(term) || '') 
      ||
      (Montagem.instaladores?.toLowerCase().includes(term) || '')
    );
  }

}

