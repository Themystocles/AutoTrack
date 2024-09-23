import { Component, OnInit } from '@angular/core';
import { FuncionarioOrcamentosResponse } from 'src/app/Models/OrcamentoFuncionarioModel';
import { FolhadepagamentoService } from '../Services/CRUD - Cliente/folhadepagamento.service';

@Component({
  selector: 'app-folhadepagamento',
  templateUrl: './folhadepagamento.component.html',
  styleUrls: ['./folhadepagamento.component.scss']
})
export class FolhadepagamentoComponent implements OnInit {
  funcionarioOrcamentos: FuncionarioOrcamentosResponse = [];
  dataInicio: string = ''; // Usar string para se ajustar ao formato do input date
  dataFim: string = ''; // Usar string para se ajustar ao formato do input date

  constructor(private folhadepagamentoService: FolhadepagamentoService) {}

  ngOnInit(): void {
    // Defina as datas iniciais, se necessário
    this.dataInicio = ''; // Exemplo de data inicial
    this.dataFim = '';   // Exemplo de data final
  }

  onSubmit(): void {
    if (this.dataInicio && this.dataFim) {
      // Converte strings para objetos Date
      const dataInicioDate = new Date(this.dataInicio);
      const dataFimDate = new Date(this.dataFim);
      
      // Chama o serviço para obter os dados com as datas inseridas
      this.getFuncionarioOrcamentos(dataInicioDate, dataFimDate);
    }
  }

  getFuncionarioOrcamentos(dataInicio: Date, dataFim: Date): void {
    this.folhadepagamentoService.getfuncionarioseorcamentos(dataInicio, dataFim)
      .subscribe({
        next: (data: FuncionarioOrcamentosResponse) => {
          this.funcionarioOrcamentos = data;
          console.log('Dados recebidos:', this.funcionarioOrcamentos); // Para debug
        },
        error: (err) => {
          console.error('Erro ao obter dados:', err);
        }
      });
  }
}
