import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Estoque } from 'src/app/Models/EstoqueModel';
import { CrudEstoqueService } from 'src/app/Services/CRUD - Cliente/crud-estoque.service';

@Component({
  selector: 'app-estoque',
  templateUrl: './estoque.component.html',
  styleUrls: ['./estoque.component.scss']
})
export class EstoqueComponent implements OnInit {
  searchTerm: string = '';

  getestoque?: Estoque[];
  estoquePost: Estoque = { id: 0, preco: 0, produto: '', quantidade: '', dataUltAlt: '' };
  estoqueput: Estoque = { id: 0, preco: 0, produto: '', quantidade: '', dataUltAlt: '' };
  estoqueid?: Estoque;
  isEditModalOpen = false;
  isAddModalOpen = false;

  constructor(
    public estoqueServices: CrudEstoqueService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getEstoque();
    this.getestoquebyid();
  }

  getEstoque() {
    this.estoqueServices.getAllEstoque().subscribe(res => this.getestoque = res);
  }
  getestoquebyid() {
    const id = String(this.route.snapshot.paramMap.get('id'));
    this.estoqueServices.getEstoquebyId(id).subscribe(res => this.estoqueid = res);
  }
  // Filtro para a lista de estoque
  getestoqueFiltered() {
    if (!this.searchTerm) {
      return this.getestoque;
    }
    return this.getestoque!.filter(estoque =>
      estoque.produto.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  openEditModal(estoque: Estoque) {
    this.estoqueput = { ...estoque };
    this.isEditModalOpen = true;
  }

  closeEditModal() {
    this.isEditModalOpen = false;
  }

  openAddModal() {
    this.estoquePost = { id: 0, preco: 0, produto: '', quantidade: '', dataUltAlt: '' };
    this.isAddModalOpen = true;
  }

  closeAddModal() {
    this.isAddModalOpen = false;
  }

  postEstoque() {
    this.estoqueServices.postEstoque(this.estoquePost).subscribe(() => {
      this.getEstoque(); // Atualiza a lista após adicionar
      this.closeAddModal(); // Fecha o modal
    });
  }

  updateEstoque() {
    if (this.estoqueput && this.estoqueput.id) {
      this.estoqueServices.putEstoque(this.estoqueput.id.toString(), this.estoqueput).subscribe(
        () => {
          this.getEstoque(); // Atualiza a lista após atualizar
          this.closeEditModal(); // Fecha o modal
        },
        error => {
          console.error('Erro ao atualizar o estoque:', error);
        }
      );
    } else {
      console.error('ID inválido ou estoqueput não definido');
    }
  }
  deleteEstoque(id: number) {
    if (confirm('Tem certeza que deseja excluir este item?')) {
      this.estoqueServices.deleteEstoque(id.toString()).subscribe(
        () => {
          this.getEstoque(); // Atualiza a lista após exclusão
        },
        error => {
          console.error('Erro ao excluir o estoque:', error);
        }
      );
    }
  }
}
