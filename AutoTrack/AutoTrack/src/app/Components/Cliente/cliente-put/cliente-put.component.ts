import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Cliente } from 'src/app/Models/ClienteModel';
import { ClientePutService } from 'src/app/Services/CRUD - Cliente/cliente-put.service';

@Component({
  selector: 'app-cliente-put',
  templateUrl: './cliente-put.component.html',
  styleUrls: ['./cliente-put.component.scss']
})
export class ClientePutComponent implements OnInit {
  clienteID!: string;
  Cliente: Cliente = {} as Cliente; // Inicialize com um objeto vazio
  showSuccessMessage = false;

  constructor(private route: ActivatedRoute, private ClienteServices: ClientePutService, private router: Router) {}

  ngOnInit(): void {
    const id = String(this.route.snapshot.paramMap.get('id'));
    this.clienteID = id;
    this.ClienteServices.getClientById(id).subscribe(res => this.Cliente = res);
  }
  
  onSubmit(form: any): void {
    if (form.valid) {
      this.ClienteServices.updateClient(this.clienteID, this.Cliente).subscribe(
        () => {
          this.showSuccessMessage = true;
          setTimeout(() => this.router.navigate(['/cliente-list']), 2000); // Redireciona após 2 segundos
        },
        error => console.error('Erro ao atualizar cliente:', error)
      );
    }
  }
}
