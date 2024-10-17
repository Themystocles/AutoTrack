import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Funcionario } from 'src/app/Models/Funcionario';
import { FuncionarioservicesService } from 'src/app/Services/CRUD - Cliente/funcionarioservices.service';
import { FuncionarioPutService } from 'src/app/Services/funcionario-put.service';

@Component({
  selector: 'app-funcionario-put',
  templateUrl: './funcionario-put.component.html',
  styleUrls: ['./funcionario-put.component.scss']
})
export class FuncionarioPutComponent implements OnInit {

funcionario: Funcionario = {} as Funcionario;
mensagemSucesso: string = '';
selectedFile: File | null = null; 

constructor(
  public funcionarioservices: FuncionarioservicesService,
  public funcionarioput : FuncionarioPutService,
  private router: Router,
  private route: ActivatedRoute
) {
}
ngOnInit(): void {
  this.getfuncionariobyId()
}

getfuncionariobyId(){
  const id = String(this.route.snapshot.paramMap.get('id'));
  this.funcionarioput.getfuncionariosbyId(id).subscribe(res => this.funcionario = res)
}
onFileSelected(event: any) {
  this.selectedFile = event.target.files[0]; // Captura o arquivo selecionado
}
salvarFuncionario(){
  this.funcionarioput.updateFuncionario(this.funcionario.id, this.funcionario).subscribe();

  this.mensagemSucesso = 'Funcionário alterado com sucesso!';
  setTimeout(() => {
    this.mensagemSucesso = '';
  }, 3000);

}

}
