import { Component, OnInit } from '@angular/core';
import { Veiculo } from '../../../Models/VeiculoModel';
import { ActivatedRoute, Router } from '@angular/router';
import { VeiculoPutService } from '../../../Services/CRUD - Cliente/veiculo-put.service';

@Component({
  selector: 'app-veiculo-put',
  templateUrl: './veiculo-put.component.html',
  styleUrls: ['./veiculo-put.component.scss']
})
export class VeiculoPutComponent implements OnInit {
  VeiculoID!: string;
  Veiculo: Veiculo = {} as Veiculo; // Inicialize com um objeto vazio
  showSuccessMessage = false;

  constructor(private route: ActivatedRoute, private VeiculoServices: VeiculoPutService, private router: Router) {}

  ngOnInit(): void {
    const id = String(this.route.snapshot.paramMap.get('id'));
    this.VeiculoID = id;
    this.VeiculoServices.GetVeiculoById(id).subscribe(res => this.Veiculo = res);
  }
  
  onSubmit(form: any): void {
    if (form.valid) {
      this.VeiculoServices.updateVeiculo(this.VeiculoID, this.Veiculo).subscribe(
        () => {
          this.showSuccessMessage = true;
          setTimeout(() => this.router.navigate(['/veiculo-list']), 2000); // Redireciona após 2 segundos
        },
        error => console.error('Erro ao atualizar Veículo:', error)
      );
    }
  }
}
