import { Component } from '@angular/core';
import { Veiculo } from '../Models/VeiculoModel';
import { FiltroVeiculoService } from '../Services/filtro-veiculo.service';

@Component({
  selector: 'app-print-mont',
  templateUrl: './print-mont.component.html',
  styleUrls: ['./print-mont.component.scss']
})
export class PrintMontComponent {
  veiculoPlaca!: string;
  veiculoChassi!: string;
  Veiculo!: Veiculo;

  // Variáveis para controle da paginação
  servicoPage: number = 1;
  servicosPerPage: number = 1;

  constructor(public FiltroServices: FiltroVeiculoService) { }

  GetveiculoByPlaca() {
    const veiculotrim = this.veiculoPlaca.trim();
    this.FiltroServices.getVeiculoByPlaca(veiculotrim).subscribe(
      res => { this.Veiculo = res },
      err => { alert("Não foram encontrados veículos com essa placa") }
    );
  }

  GetveiculoByChassi() {
    const veiculochassitrim = this.veiculoChassi.trim();
    this.FiltroServices.getVeiculoBychassi(veiculochassitrim).subscribe(
      res => { this.Veiculo = res },
      err => { alert("Não foram encontrados veículos com o chassi informado") }
    );
  }
}

