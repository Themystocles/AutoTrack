import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Funcionario } from 'src/app/Models/Funcionario';
import { FuncionarioservicesService } from 'src/app/Services/CRUD - Cliente/funcionarioservices.service';

@Component({
  selector: 'app-funcionario',
  templateUrl: './funcionario.component.html',
  styleUrls: ['./funcionario.component.scss']
})
export class FuncionarioComponent implements OnInit {

  funcionario : Funcionario[] = []
  FuncionarioId! : Funcionario

constructor(
  public funcionarioservices: FuncionarioservicesService,
  private router: Router,
  private route: ActivatedRoute
) {
}

ngOnInit(): void {
  this.getAllfuncionarios()
}
getAllfuncionarios(){
  this.funcionarioservices.getfuncionarios().subscribe(res => this.funcionario = res)

}
getfuncionariobyId(){
  const id = String(this.route.snapshot.paramMap.get('id'));
  this.funcionarioservices.getfuncionariosbyId(id).subscribe(res => this.FuncionarioId = res)
}

}
